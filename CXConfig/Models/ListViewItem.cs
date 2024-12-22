namespace CXConfig.View;
public class BottleViewItem
{
    public BottleItem(string name, string folderFullPath, string configFullPath, string alternativeConfigFileFullpath){
        Name = name;
        FolderFullPath = folderFullPath;
        ConfigFileFullPath = configFullPath;
        AlternativeConfigFileFullpath = alternativeConfigFileFullpath;
    }
    public string Name { get; set; }
    public string FolderFullPath { get; set; }
    public string ConfigFileFullPath { get; set; } 
    public string AlternativeConfigFileFullpath { get; set; }
}