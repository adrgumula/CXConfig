using AuthenticationServices;

namespace CXConfig.View;
public class BottleItem
{
    public BottleItem(string name, string folderFullPath, string configFullPath, string description, string alternativeConfigFileFullpath,  Dictionary<string, string>? confgFileDictionary = null){
        Name = name;
        FolderFullPath = folderFullPath;
        ConfigFileFullPath = configFullPath;
        AlternativeConfigFileFullpath = alternativeConfigFileFullpath;
        Description = description;
        ConfgFileDictionary = confgFileDictionary;
    }
    public string Name { get; set; }
    public string Description {get;set;}
    public string FolderFullPath { get; set; }
    public string ConfigFileFullPath { get; set; } 
    public string AlternativeConfigFileFullpath { get; set; }

    public  Dictionary<string, string>? ConfgFileDictionary {get;}
}