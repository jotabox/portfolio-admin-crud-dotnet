using System.Collections.Generic;
using System.Reflection;

namespace Domain.Authorization.Permissions
{
    public static class PermissionNames
    {
        public static List<string> GetAllPermissions()
        {
            var permissions = new List<string>();

            // Procura TODAS as classes dentro deste namespace
            var permissionClasses = Assembly.GetExecutingAssembly()
                .GetTypes();

            foreach (var type in permissionClasses)
            {
                if (type.Namespace != null &&
                    type.Namespace.Contains("Domain.Authorization.Permissions") &&
                    type.IsClass && type.IsAbstract && type.IsSealed) // static class
                {
                    var fields = type.GetFields(BindingFlags.Public | BindingFlags.Static);

                    foreach (var field in fields)
                    {
                        if (field.FieldType == typeof(string))
                        {
                            permissions.Add(field.GetValue(null).ToString()!);
                        }
                    }
                }
            }

            return permissions;
        }
    }
}
