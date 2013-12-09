using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace CsQueryControls.Helper {
    public static class ControlHelper {
        public static string GetDisplayName<TModel, TProperty>(Expression<Func<TModel, TProperty>> expression) {
            var type = typeof(TModel);
            var memberExpression = (MemberExpression)expression.Body;
            var propertyName = ((memberExpression.Member is PropertyInfo) ? memberExpression.Member.Name : string.Empty);
            return GetDisplayName(type, propertyName);
        }
        public static string GetDisplayName(Type type, string propertyName) {
            var attr = (DisplayAttribute)type.GetProperty(propertyName).GetCustomAttributes(typeof(DisplayAttribute), true).SingleOrDefault();
            if (attr == null) {
                var metadataType = (MetadataTypeAttribute)type.GetCustomAttributes(typeof(MetadataTypeAttribute), true).FirstOrDefault();
                if (metadataType != null) {
                    var property = metadataType.MetadataClassType.GetProperty(propertyName);
                    if (property != null) {
                        attr = (DisplayAttribute)property.GetCustomAttributes(typeof(DisplayNameAttribute), true).SingleOrDefault();
                    }
                }
            }
            var name = string.Empty;
            if (attr != null) {
                name = attr.ResourceType != null
                    ? attr.ResourceType.GetProperty(attr.Name).GetValue(null).ToString()
                    : attr.Name;
            }
            return name;


        }
        public static string GetDisplayFormat<TModel, TProperty>(Expression<Func<TModel, TProperty>> expression) {
            var type = typeof(TModel);
            var memberExpression = (MemberExpression)expression.Body;
            var propertyName = ((memberExpression.Member is PropertyInfo) ? memberExpression.Member.Name : string.Empty);
            return GetDisplayFormat(type, propertyName);
        }
        public static string GetDisplayFormat(Type type, string propertyName) {
            var attr = (DisplayFormatAttribute)type.GetProperty(propertyName).GetCustomAttributes(typeof(DisplayFormatAttribute), true).SingleOrDefault();
            if (attr == null) {
                var metadataType = (MetadataTypeAttribute)type.GetCustomAttributes(typeof(MetadataTypeAttribute), true).FirstOrDefault();
                if (metadataType != null) {
                    var property = metadataType.MetadataClassType.GetProperty(propertyName);
                    if (property != null) {
                        attr = (DisplayFormatAttribute)property.GetCustomAttributes(typeof(DisplayFormatAttribute), true).SingleOrDefault();
                    }
                }
            }
            return (attr != null) ? attr.DataFormatString : String.Empty;


        }
    }
}