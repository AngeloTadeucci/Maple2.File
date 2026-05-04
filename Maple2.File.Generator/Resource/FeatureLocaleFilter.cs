using System;
using System.Collections.Generic;
using System.Linq;

namespace M2dXmlGenerator;

public static class FeatureLocaleFilter {
    public static string Locale = string.Empty;
    public static Dictionary<string, int> Features = new Dictionary<string, int>();

    public static T FeatureLocale<T>(this T result) where T : IFeatureLocale {
        if (result != null && FeatureEnabled(result.Feature) && HasLocale(result.Locale)) {
            return result;
        }

        return default(T);
    }

    public static IEnumerable<T> FeatureLocale<T>(this IEnumerable<T> results) where T : IFeatureLocale {
        return results.Where(data => FeatureEnabled(data.Feature) && HasLocale(data.Locale));
    }

    public static T ResolveFeatureLocale<T>(this IEnumerable<T> results) where T : IFeatureLocale {
        return results.FeatureLocale().Resolve();
    }

    public static IEnumerable<T> ResolveFeatureLocale<T, TK>(this IEnumerable<T> results, Func<T, TK> groupSelector) where T : IFeatureLocale {
        foreach (IGrouping<TK, T> grouping in results.GroupBy(groupSelector)) {
            T result = grouping.ResolveFeatureLocale();
            if (result != null) {
                yield return result;
            }
        }
    }

    public static bool FeatureEnabled(string feature) {
        return string.IsNullOrEmpty(feature) || Features.ContainsKey(feature);
    }

    public static bool HasLocale(string locale) {
        return string.IsNullOrEmpty(locale) || Locale.Equals(locale, StringComparison.OrdinalIgnoreCase);
    }

    private static T Resolve<T>(this IEnumerable<T> enumerable) where T : IFeatureLocale {
        List<T> entries = enumerable.ToList();

        // Matching locale is preferred over empty locale.
        List<T> filtered = entries.Where(entry => Locale.Equals(entry.Locale, StringComparison.OrdinalIgnoreCase)).ToList();
        if (filtered.Count == 0) {
            filtered = entries.Where(entry => string.IsNullOrEmpty(entry.Locale)).ToList();
        }

        // If no matches, just return null.
        T result = default(T);
        int maxVersion = -1;

        // Now that we have filtered on locale, resolve by feature with the highest version.
        foreach (T entry in filtered) {
            // Unspecified feature is lowest priority for matching.
            if (string.IsNullOrWhiteSpace(entry.Feature)) {
                if (maxVersion == -1) {
                    result = entry;
                }
                continue;
            }

            int version = Features[entry.Feature];
            if (version > maxVersion ||
                // This is how the client resolves same version matches. Dumb as bricks.
                (version == maxVersion && string.Compare(entry.Feature, result.Feature, StringComparison.Ordinal) > 0)) {
                result = entry;
                maxVersion = version;
            }
        }

        return result;
    }
}
