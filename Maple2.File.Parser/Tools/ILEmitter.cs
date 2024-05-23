using System;
using System.Collections;
using System.Drawing;
using System.Numerics;
using System.Reflection;
using System.Reflection.Emit;

namespace Maple2.File.Parser.Tools;

// https://sharplab.io to preview IL for code.
public static class ILEmitter {
    public static void EmitValue(this ILGenerator il, object value) {
        if (value is IDictionary dictionary) {
            il.Emit(OpCodes.Newobj, value.GetType().GetConstructor(Type.EmptyTypes));
            foreach (DictionaryEntry entry in dictionary) {
                // 0th arg to Add is "this"
                il.Emit(OpCodes.Dup);
                EmitValue(il, entry.Key);
                EmitValue(il, entry.Value);
                il.Emit(OpCodes.Callvirt, value.GetType().GetMethod("Add"));
            }
        } else if (value is bool boolValue) {
            il.Emit(boolValue ? OpCodes.Ldc_I4_1 : OpCodes.Ldc_I4_0);
        } else if (value is ushort ushortValue) {
            il.Emit(OpCodes.Ldc_I4, ushortValue);
        } else if (value is uint uintValue) {
            il.Emit(OpCodes.Ldc_I4, uintValue);
        } else if (value is int intValue) {
            il.Emit(OpCodes.Ldc_I4, intValue);
        } else if (value is float floatValue) {
            il.Emit(OpCodes.Ldc_R4, floatValue);
        } else if (value is double doubleValue) {
            il.Emit(OpCodes.Ldc_R8, doubleValue);
        } else if (value is string stringValue) {
            il.Emit(OpCodes.Ldstr, stringValue);
        } else if (value is Vector3 vector3Value) {
            ConstructorInfo constructor =
                typeof(Vector3).GetConstructor(new[] { typeof(float), typeof(float), typeof(float) });

            il.Emit(OpCodes.Ldc_R4, vector3Value.X);
            il.Emit(OpCodes.Ldc_R4, vector3Value.Y);
            il.Emit(OpCodes.Ldc_R4, vector3Value.Z);
            il.Emit(OpCodes.Newobj, constructor);
        } else if (value is Vector2 vector2Value) {
            ConstructorInfo constructor = typeof(Vector2).GetConstructor(new[] { typeof(float), typeof(float) });

            il.Emit(OpCodes.Ldc_R4, vector2Value.X);
            il.Emit(OpCodes.Ldc_R4, vector2Value.Y);
            il.Emit(OpCodes.Newobj, constructor);
        } else if (value is Color colorValue) {
            MethodInfo method =
                typeof(Color).GetMethod("FromArgb", new[] { typeof(int), typeof(int), typeof(int), typeof(int) });

            il.Emit(OpCodes.Ldc_I4, (int) colorValue.A);
            il.Emit(OpCodes.Ldc_I4, (int) colorValue.R);
            il.Emit(OpCodes.Ldc_I4, (int) colorValue.G);
            il.Emit(OpCodes.Ldc_I4, (int) colorValue.B);
            il.Emit(OpCodes.Call, method);
        } else {
            throw new NotImplementedException($"Unable to generate IL for {value.GetType().FullName}");
        }
    }
}
