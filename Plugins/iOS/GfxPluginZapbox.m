#import <Foundation/Foundation.h>
#include "IUnityInterface.h"

#import "UnityAppController.h"

#ifdef __cplusplus
extern "C" {
#endif

void UNITY_INTERFACE_EXPORT UNITY_INTERFACE_API UnityPluginLoad(IUnityInterfaces* unityInterfaces);
void UNITY_INTERFACE_EXPORT UNITY_INTERFACE_API UnityPluginUnload();

#ifdef __cplusplus
} // extern "C"
#endif

extern UIViewController *UnityGetGLViewController(); // Root view controller of Unity screen.
extern void ZapboxDisplay_SetUnityViewController(UIViewController* unity_view_controller);

@interface GfxPluginZapbox: NSObject

+ (void)loadPlugin;

@end

@implementation GfxPluginZapbox

+ (void)loadPlugin
{
    // unlike desktops where plugin dynamic library is automatically loaded and registered
	// we need to do that manually on iOS
    UnityRegisterRenderingPluginV5(&UnityPluginLoad, &UnityPluginUnload);
    
    ZapboxDisplay_SetUnityViewController(UnityGetGLViewController());
}

@end
