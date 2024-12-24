using System;

namespace CXConfig.Common;

public static class Names
{
    public const string CXPatcherBottleFolderName = "CXPBottles";
    public const string BottleConfigFileEntryRegEx = @"^\s*""([^""]+)""\s*=\s*""([^""]+)"""; //"\"([^\"]+)\"\\s*=\\s*\"([^\"]+)\"";
    public const string BottleConfigFileCommentedLine  = ";;";
}

public static class Files
{
    public const string CXBottleConfig = "cxbottle.conf";
    public const string DxvkConfig = "dxvkfiles.conf";
}

