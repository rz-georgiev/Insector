﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Insector.Data {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class SeedingResources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal SeedingResources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Insector.Data.SeedingResources", typeof(SeedingResources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to [
        ///	{
        ///		&quot;Id&quot; : 1,
        ///		&quot;Title&quot; : &quot;Default&quot;,
        ///		&quot;Description&quot; : &quot;Default&quot;
        ///	},
        ///	{
        ///		&quot;Id&quot; : 2,
        ///		&quot;Title&quot; : &quot;Administrator&quot;,
        ///		&quot;Description&quot; : &quot;Administrator&quot;
        ///	}
        ///].
        /// </summary>
        internal static string Roles {
            get {
                return ResourceManager.GetString("Roles", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to [
        ///	{
        ///		&quot;Id&quot; : 1,
        ///		&quot;Email&quot; : &quot;default_user@gmail.com&quot;,
        ///		&quot;PasswordHash&quot; : &quot;AKuLcq62eEe910jv3QkLqqsajq3x6FkzziClOSSzc0TvF7RFQmwGRSH6ALZxs\/HOMg==&quot;,
        ///		&quot;AvatarUrl&quot; : &quot;https:\/\/cdn.icon-icons.com\/icons2\/1378\/PNG\/512\/avatardefault_92824.png&quot;,
        ///		&quot;Nickname&quot; : &quot;Default&quot;,
        ///		&quot;IsActive&quot; : 1,
        ///		&quot;IsEmailConfirmed&quot; : 1
        ///	}
        ///].
        /// </summary>
        internal static string Users {
            get {
                return ResourceManager.GetString("Users", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to [
        ///	{
        ///		&quot;Id&quot; : 1,
        ///		&quot;UserId&quot; : 1,
        ///		&quot;RoleId&quot; : 2
        ///	}
        ///].
        /// </summary>
        internal static string UsersRoles {
            get {
                return ResourceManager.GetString("UsersRoles", resourceCulture);
            }
        }
    }
}