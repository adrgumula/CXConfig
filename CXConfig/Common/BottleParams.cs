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
    ["DXMT_METALFX_SPATIAL_SWAPCHAIN"] = "1"
    ["WINEMSYNC"] ="1"
    */
    public const string DXVK_ASYNC_NAME = "DXVK_ASYNC";
    public static readonly string[] DXVK_ASYNC_PARAMS = ["0", "1"];
    
    public const string ROSETTA_ADVERTISE_AVX = "ROSETTA_ADVERTISE_AVX";
    public static readonly string[] ROSETTA_ADVERTISE_AVX_PARAMS = ["0", "1"];

    public const string MTL_HUD_ENABLED_NAME = "MTL_HUD_ENABLED";
    public static readonly string[] MTL_HUD_ENABLED_PARAMS = ["0", "1"];

    public const string DXMT_CONFIG_NAME = "DXMT_CONFIG";
    public const string DXMT_CONFIG_METAL_SPATIAL_UPSCALE_FACTOR_NAME = "d3d11.metalSpatialUpscaleFactor";
    public static readonly float[] DXMT_CONFIG_METAL_SPATIAL_UPSCALE_FACTOR_PARAMS = [1.0f, 1.1f, 1.2f, 1.3f, 1.4f, 1.5f, 1.6f, 1.7f, 1.8f, 1.9f, 2.0f];
    public const string DXMT_CONFIG_METAL_PREFERED_MAX_FRAME_RATE_NAME = "d3d11.preferredMaxFrameRate";
    public static readonly float[] DXMT_CONFIG_METAL_PREFERED_MAX_FRAME_RATE_PARAMS = [30.0f, 60.0f, 120.0f, 240.0f];
    
    public const string DXMT_METALFX_SPATIAL_SWAPCHAIN_NAME = "DXMT_METALFX_SPATIAL_SWAPCHAIN";
    public static readonly string[] DXMT_METALFX_SPATIAL_SWAPCHAIN_PARAMS = ["0", "1"];
    
    public const string WINEMSYNC_NAME = "WINEMSYNC";
    public static readonly string[] WINEMSYNCPARAMS = ["0", "1"];

    public static readonly string[] BottleConfigFileParamsList = [
        DXVK_ASYNC_NAME,
        ROSETTA_ADVERTISE_AVX,
        MTL_HUD_ENABLED_NAME,
        DXMT_CONFIG_NAME,
        DXMT_CONFIG_METAL_SPATIAL_UPSCALE_FACTOR_NAME,
        DXMT_CONFIG_METAL_PREFERED_MAX_FRAME_RATE_NAME,
        DXMT_METALFX_SPATIAL_SWAPCHAIN_NAME,
        WINEMSYNC_NAME
    ];
}
