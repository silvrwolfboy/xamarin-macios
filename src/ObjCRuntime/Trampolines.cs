//
// Trampoline caching support
//
// Copyright 2013 Xamarin Inc
//
// Authors:
//   Miguel de Icaza (miguel@xamarin.com)
//
using System;
using System.Reflection;
using System.Collections.Generic;
using System.Runtime.InteropServices;

using ObjCRuntime;

namespace ObjCRuntime {

	public static partial class Trampolines {
		
#if !XAMCORE_2_0
		static Dictionary<IntPtr,Delegate> cache;
		public static Delegate Lookup (IntPtr methodPtr, Type type)
		{
			if (cache == null)
				cache = new Dictionary<IntPtr, Delegate> (Runtime.IntPtrEqualityComparer);

			// We do not care if there is a race condition and we initialize two caches
			// since the worst that can happen is that we end up with an extra
			// delegate->function pointer.
			Delegate val;
			lock (cache) {
				if (cache.TryGetValue (methodPtr, out val))
					return val;
			}

			val = Marshal.GetDelegateForFunctionPointer (methodPtr, type);

			lock (cache){
				cache [methodPtr] = val;
			}
			return val;
		}
#endif

		[UnmanagedFunctionPointerAttribute (CallingConvention.Cdecl)]
		[UserDelegateType (typeof (global::System.Action))]
		internal delegate void D_DispatchBlock_Action (IntPtr block);

		static internal class SDAction_DispatchBlock_SetEventHandler {
			static internal readonly D_DispatchBlock_Action Handler = Invoke;

			[MonoPInvokeCallback (typeof (D_DispatchBlock_Action))]
			static unsafe void Invoke (IntPtr block) {
				var descriptor = (BlockLiteral *) block;
				var del = (global::System.Action) (descriptor->Target);
				if (del != null)
					del ();
			}
		} /* class SDAction */

		static internal class SDAction_DispatchBlock_SetRegistrationHandler {
			static internal readonly D_DispatchBlock_Action Handler = Invoke;

			[MonoPInvokeCallback (typeof (D_DispatchBlock_Action))]
			static unsafe void Invoke (IntPtr block) {
				var descriptor = (BlockLiteral *) block;
				var del = (global::System.Action) (descriptor->Target);
				if (del != null)
					del ();
			}
		} /* class SDAction */

		static internal class SDAction_DispatchBlock_SetCancelHandler {
			static internal readonly D_DispatchBlock_Action Handler = Invoke;

			[MonoPInvokeCallback (typeof (D_DispatchBlock_Action))]
			static unsafe void Invoke (IntPtr block) {
				var descriptor = (BlockLiteral *) block;
				var del = (global::System.Action) (descriptor->Target);
				if (del != null)
					del ();
			}
		} /* class SDAction */
	}
}