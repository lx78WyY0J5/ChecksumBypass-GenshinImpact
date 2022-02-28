using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using UnhollowerBaseLib;

namespace ChecksumBypass {

    public static class ModBuildInfo {
        public const string Name = "GenshinChecksumBypass";
        public const string Author = "nitro.";
        public const string Version = "1.0.0";
        public const string DownloadLink = null;
        public const string Company = null;
        public const string GameDeveloper = "miHoYo";
        public const string Game = "Genshin Impact";
    }

    public class Main : MelonMod {

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PlayerLoginReqProtoStringSettersDelegate(IntPtr instance, IntPtr value, IntPtr nativeMethodPointer);

        private static List<Delegate> dontGcDelegates = new List<Delegate>();

        public override void OnApplicationStart() {
            MelonLogger.Msg("Mod loaded.");
            unsafe {
                var properties = typeof(Object1PublicSealedIEquatable1ObfMJ1ObKJInOCStONKPInUnique).GetProperties(BindingFlags.Instance | BindingFlags.Public);

                foreach (var property in properties.Where(p => (p.PropertyType == typeof(string)) && (p.SetMethod.CustomAttributes.Count() == 1))) {
                    var originalMethod = property.SetMethod;

                    PlayerLoginReqProtoStringSettersDelegate tempDelegate, originalDelegate = null;

                    tempDelegate = (instance, value, nativeMethodPointer) => {
                        var convertedString = IL2CPP.Il2CppStringToManaged(value);
                        if (convertedString.Length == 66) {
                            MelonLogger.Msg("Original checksum: " + convertedString);
                            MelonLogger.Msg("Setting checksum in function " + originalMethod.Name);
                            // var checksum2.2 = "601f9d24a9f983df28cdbfe40d6ca4d0c30f8297a7b37ed3b7a082df15aff9771d";
                            // var checksum2.3 = "37dfc56fd2bf5fa0d3ec55b4f2a81d374c9c8c5382645c32f97495469dbf036e1f";
                            // var checksum2.4 = "c1218c188819cba2e794c29c6f5c0f2248eefb4cd29f29b18619e7626f83044a20";
                            var checksum = "6c0b1b9b176af5f26038400b229381ec952eff387d738841a7940725c457b0ae23";
                            originalDelegate(instance, IL2CPP.ManagedStringToIl2Cpp(checksum), nativeMethodPointer);
                        } else {
                            originalDelegate(instance, value, nativeMethodPointer);
                        }
                    };

                    dontGcDelegates.Add(tempDelegate);

                    var originalMethodPointer = *(IntPtr*)(IntPtr)UnhollowerUtils.GetIl2CppMethodInfoPointerFieldForGeneratedMethod(originalMethod).GetValue(null);
                    var delegateDetourPointer = Marshal.GetFunctionPointerForDelegate(tempDelegate);

                    MelonUtils.NativeHookAttach((IntPtr)(&originalMethodPointer), delegateDetourPointer);

                    originalDelegate = Marshal.GetDelegateForFunctionPointer<PlayerLoginReqProtoStringSettersDelegate>(originalMethodPointer);
                }

                MelonLogger.Msg("Hooked PlayerLoginReq proto setters.");
            }
            
        }

    }
}
