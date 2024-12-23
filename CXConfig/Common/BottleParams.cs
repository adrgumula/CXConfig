using System;
using AddressBook;

namespace CXConfig.Common;

public static class BottleParams
{
    /*
["DXVK_ASYNC"] ="1"
["ROSETTA_ADVERTISE_AVX"] ="1"
["MTL_HUD_ENABLED"] ="1"
["DXMT_CONFIG"] ="d3d11.metalSpatialUpscaleFactor=1.0;d3d11.preferredMaxFrameRate=60.0;"
["DXMT_METALFX_SPATIAL_SWAPCHAIN"] ="1"
["WINEMSYNC"] ="1"

    */
    public const string DXVK_ASYNC = "DXVK_ASYNC";
    public static readonly string[] DXVK_ASYNC_PARAMS = ["0", "1"];
    
    public const string ROSETTA_ADVERTISE_AVX = "ROSETTA_ADVERTISE_AVX";
    public static readonly string[] ROSETTA_ADVERTISE_AVX_PARAMS = ["0", "1"];

    public const string MTL_HUD_ENABLED = "MTL_HUD_ENABLED";
    public static readonly string[] MTL_HUD_ENABLED_PARAMS = ["0", "1"];

    public const string DXMT_CONFIG = "DXMT_CONFIG";
    public static readonly string[] DXMT_CONFIG_PARAMS = ["0", "1"];
    
    public const string DXMT_METALFX_SPATIAL_SWAPCHAIN = "DXMT_METALFX_SPATIAL_SWAPCHAIN";
    public static readonly string[] DXMT_METALFX_SPATIAL_SWAPCHAIN_PARAMS = ["0", "1"];
    
    public const string WINEMSYNC = "WINEMSYNC";
    public static readonly string[] WINEMSYNCPARAMS = ["0", "1"];
}
