using UnityEditor;

public static class PackageManagerProxy
{
    public static UnityEditor.PackageManager.PackageInfo[] GetAllVisiblePackages()
    {
        return PackageManagerUtilityInternal.GetAllVisiblePackages();
    }
}
