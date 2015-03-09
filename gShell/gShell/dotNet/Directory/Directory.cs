﻿using System;
using System.Collections.Generic;
using directory_v1 = Google.Apis.Admin.Directory.directory_v1;
using Data = Google.Apis.Admin.Directory.directory_v1.Data;
using gShell.dotNet;
using gShell.dotNet.Utilities.OAuth2;

namespace gShell.dotNet
{
    public abstract class Directory : ServiceWrapper<directory_v1.DirectoryService>
    {
        #region Inherited Members
        protected static bool worksWithGmail = false;

        protected static directory_v1.DirectoryService CreateNewService(string domain)
        {
            return new directory_v1.DirectoryService(OAuth2Base.GetInitializer(domain));
        }
        #endregion

        #region Wrapped Methods
        //the following methods assume that the service has been authenticated first.

        #region Chromeosdevices
        public class ChromeosDevices
        {
            public class ChromeosDevicesListProperties
            {
                public int maxResults=100;
                public directory_v1.ChromeosdevicesResource.ListRequest.OrderByEnum? orderBy=null;
                public directory_v1.ChromeosdevicesResource.ListRequest.ProjectionEnum? projection=null;
                public directory_v1.ChromeosdevicesResource.ListRequest.SortOrderEnum? sortOrder = null;
                public Action<string, string> startProgressBar = null;
                public Action<int, int, string, string> updateProgressBar = null;
                public int totalResults = 0;
            }

            public static Data.ChromeOsDevice Get(string customerId, string deviceId,
                directory_v1.ChromeosdevicesResource.GetRequest.ProjectionEnum? projection=null)
            {
                directory_v1.ChromeosdevicesResource.GetRequest request =
                 services[activeDomain].Chromeosdevices.Get(customerId, deviceId);
                request.Projection = projection;
                return request.Execute();
            }

            public static List<Data.ChromeOsDevice> List(string customerId, ChromeosDevicesListProperties properties = null)
            {
                List<Data.ChromeOsDevice> results = new List<Data.ChromeOsDevice>();

                directory_v1.ChromeosdevicesResource.ListRequest request = 
                 services[activeDomain].Chromeosdevices.List(customerId);

                if (properties != null)
                {
                    request.MaxResults = properties.maxResults;
                    request.OrderBy = properties.orderBy;
                    request.Projection = properties.projection;
                    request.SortOrder = properties.sortOrder;
                }

                string resultObjType = "Chrome OS Devices";

                properties.startProgressBar("Gathering " + resultObjType,
                    string.Format("-Collecting {0} {1} to {2}", resultObjType, "1", request.MaxResults.ToString()));

                Data.ChromeOsDevices pagedResult = request.Execute();

                results.AddRange(pagedResult.Chromeosdevices);

                while (!string.IsNullOrWhiteSpace(pagedResult.NextPageToken) &&
                    pagedResult.NextPageToken != request.PageToken &&
                (properties.totalResults == 0 || results.Count < properties.totalResults))
                {
                    request.PageToken = pagedResult.NextPageToken;
                    properties.updateProgressBar(5, 10, "Gathering " + resultObjType,
                            string.Format("-Collecting {0} {1} to {2}",
                                resultObjType,
                                (results.Count + 1).ToString(),
                                (results.Count + request.MaxResults).ToString()));
                    pagedResult = request.Execute();
                    results.AddRange(pagedResult.Chromeosdevices);
                }

                properties.updateProgressBar(1, 2, "Gathering " + resultObjType,
                        string.Format("-Returning {0} results.", results.Count.ToString()));

                return results;
            }

            public static Data.ChromeOsDevice Patch(Data.ChromeOsDevice body, string customerId, string deviceId,
                directory_v1.ChromeosdevicesResource.PatchRequest.ProjectionEnum? projection=null)
            {
                directory_v1.ChromeosdevicesResource.PatchRequest request =
                 services[activeDomain].Chromeosdevices.Patch(body, customerId, deviceId);
                request.Projection = projection;
                return request.Execute();
            }

            public static Data.ChromeOsDevice Update(Data.ChromeOsDevice body, string customerId, string deviceId,
                directory_v1.ChromeosdevicesResource.UpdateRequest.ProjectionEnum? projection = null)
            {
                directory_v1.ChromeosdevicesResource.UpdateRequest request =
                 services[activeDomain].Chromeosdevices.Update(body, customerId, deviceId);
                request.Projection = projection;
                return request.Execute();
            }
        }
        #endregion

        #region Groups
        public class Groups
        {
            public class GroupsListProperties
            {
                public string customer = null;
                public string domain = null;
                public string userKey = null;
                public int maxResults = 200;
                public Action<string, string> startProgressBar = null;
                public Action<int, int, string, string> updateProgressBar = null;
                public int totalResults = 0;
            }

            public static string Delete(string groupKey)
            {
                return services[activeDomain].Groups.Delete(groupKey).Execute();
            }

            public static Data.Group Get(string groupKey)
            {
                return services[activeDomain].Groups.Get(groupKey).Execute();
            }

            public static Data.Group Insert(Data.Group body)
            {
                return services[activeDomain].Groups.Insert(body).Execute();
            }

            public static List<Data.Group> List(GroupsListProperties properties = null)
            {
                List<Data.Group> results = new List<Data.Group>();

                directory_v1.GroupsResource.ListRequest request =
                 services[activeDomain].Groups.List();

                if (null != properties)
                {
                    request.MaxResults = properties.maxResults;
                    request.Domain = properties.domain;
                    request.Customer = properties.customer;
                    request.UserKey = properties.userKey;
                }

                string resultObjType = "groups";

                properties.startProgressBar("Gathering " + resultObjType,
                    string.Format("-Collecting {0} {1} to {2}", resultObjType, "1", request.MaxResults.ToString()));
                
                Data.Groups pagedResult = request.Execute();

                results.AddRange(pagedResult.GroupsValue);

                while (!string.IsNullOrWhiteSpace(pagedResult.NextPageToken) &&
                    pagedResult.NextPageToken != request.PageToken &&
                (properties.totalResults == 0 || results.Count < properties.totalResults))
                {
                    request.PageToken = pagedResult.NextPageToken;
                    properties.updateProgressBar(5, 10, "Gathering " + resultObjType,
                            string.Format("-Collecting {0} {1} to {2}",
                                resultObjType,
                                (results.Count + 1).ToString(),
                                (results.Count + request.MaxResults).ToString()));
                    pagedResult = request.Execute();
                    results.AddRange(pagedResult.GroupsValue);
                }

                properties.updateProgressBar(1, 2, "Gathering " + resultObjType,
                        string.Format("-Returning {0} results.", results.Count.ToString()));

                return results;
            }

            public static Data.Group Patch(Data.Group body, string groupKey)
            {
                return services[activeDomain].Groups.Patch(body, groupKey).Execute();
            }

            public static Data.Group Update(Data.Group body, string groupKey)
            {
                return services[activeDomain].Groups.Update(body, groupKey).Execute();
            }

            #region Groups.aliases
            public class Aliases
            {
                public static string Delete(string groupKey, string alias)
                {
                    return services[activeDomain].Groups.Aliases.Delete(groupKey, alias).Execute();
                }

                public static Data.Alias Insert(Data.Alias body, string groupKey)
                {
                    return services[activeDomain].Groups.Aliases.Insert(body, groupKey).Execute();
                }

                public static List<Data.Alias> List(string groupKey)
                {
                    List<Data.Alias> results = new List<Data.Alias>();

                    directory_v1.GroupsResource.AliasesResource.ListRequest request =
                     services[activeDomain].Groups.Aliases.List(groupKey);

                    Data.Aliases pagedResult = request.Execute();

                    results.AddRange(pagedResult.AliasesValue);

                    return results;
                }
            }
            #endregion

        }
        #endregion

        #region Members
        public class Members
        {
            public class MembersListProperties
            {
                public string roles = null;
                public int maxResults = 200;
                public Action<string, string> startProgressBar = null;
                public Action<int, int, string, string> updateProgressBar = null;
                public int totalResults = 0;
            }

            public static string Delete(string groupKey, string memberKey)
            {
                return services[activeDomain].Members.Delete(groupKey, memberKey).Execute();
            }

            public static Data.Member Get(string groupKey, string memberKey)
            {
                return services[activeDomain].Members.Get(groupKey, memberKey).Execute();
            }

            public static Data.Member Insert(Data.Member body, string groupKey)
            {
                return services[activeDomain].Members.Insert(body, groupKey).Execute();
            }

            public static List<Data.Member> List(string groupKey, MembersListProperties properties = null)
            {
                List<Data.Member> results = new List<Data.Member>();
                
                directory_v1.MembersResource.ListRequest request =
                 services[activeDomain].Members.List(groupKey);

                if (null != properties)
                {
                    request.Roles = properties.roles;
                    request.MaxResults = properties.maxResults;
                }

                string resultObjType = "group members";

                properties.startProgressBar("Gathering " + resultObjType,
                    string.Format("-Collecting {0} {1} to {2}", resultObjType, "1", request.MaxResults.ToString()));

                Data.Members pagedResult = request.Execute();

                results.AddRange(pagedResult.MembersValue);

                while (!string.IsNullOrWhiteSpace(pagedResult.NextPageToken) &&
                    pagedResult.NextPageToken != request.PageToken &&
                (properties.totalResults == 0 || results.Count < properties.totalResults))
                {
                    request.PageToken = pagedResult.NextPageToken;
                    properties.updateProgressBar(5, 10, "Gathering " + resultObjType,
                            string.Format("-Collecting {0} {1} to {2}",
                                resultObjType,
                                (results.Count + 1).ToString(),
                                (results.Count + request.MaxResults).ToString()));
                    results.AddRange(pagedResult.MembersValue);
                }

                properties.updateProgressBar(1, 2, "Gathering " + resultObjType,
                        string.Format("-Returning {0} results.", results.Count.ToString()));

                return results;
            }

            public static Data.Member Patch(Data.Member body, string groupKey, string memberKey)
            {
                return services[activeDomain].Members.Patch(body, groupKey, memberKey).Execute();
            }

            public static Data.Member Update(Data.Member body, string groupKey, string memberKey)
            {
                return services[activeDomain].Members.Update(body, groupKey, memberKey).Execute();
            }
        }
        #endregion

        #region MobileDevices
        public class MobileDevices
        {
            public class MobileDevicesPropertiesList
            {
                public int maxResults = 100;
                public directory_v1.MobiledevicesResource.ListRequest.OrderByEnum? orderBy = null;
                public directory_v1.MobiledevicesResource.ListRequest.ProjectionEnum? projection = null;
                public directory_v1.MobiledevicesResource.ListRequest.SortOrderEnum? sortOrder = null;
                public Action<string, string> startProgressBar = null;
                public Action<int, int, string, string> updateProgressBar = null;
                public int totalResults = 0;
            }

            public static string Action(Data.MobileDeviceAction body, string customerId, string resourceId)
            {
                return services[activeDomain].Mobiledevices.Action(body, customerId, resourceId).Execute();
            }

            public static string Delete(string customerId, string resourceId)
            {
                return services[activeDomain].Mobiledevices.Delete(customerId, resourceId).Execute();
            }

            public static Data.MobileDevice Get(string customerId, string resourceId,
                directory_v1.MobiledevicesResource.GetRequest.ProjectionEnum? projection = null)
            {
                directory_v1.MobiledevicesResource.GetRequest request = 
                    services[activeDomain].Mobiledevices.Get(customerId, resourceId);
                request.Projection = projection;
                return request.Execute();
            }

            public static List<Data.MobileDevice> List(string customerId,MobileDevicesPropertiesList properties = null)
            {
                List<Data.MobileDevice> results = new List<Data.MobileDevice>();

                directory_v1.MobiledevicesResource.ListRequest request = 
                    services[activeDomain].Mobiledevices.List(customerId);

                if (null != properties)
                {
                    request.MaxResults = properties.maxResults;
                    request.OrderBy = properties.orderBy;
                    request.Projection = properties.projection;
                    request.SortOrder = properties.sortOrder;
                }

                string resultObjType = "mobile devices";

                properties.startProgressBar("Gathering " + resultObjType,
                    string.Format("-Collecting {0} {1} to {2}", resultObjType, "1", request.MaxResults.ToString()));

                Data.MobileDevices pagedResult = request.Execute();

                results.AddRange(pagedResult.Mobiledevices);

                while (!string.IsNullOrWhiteSpace(pagedResult.NextPageToken) &&
                    pagedResult.NextPageToken != request.PageToken &&
                (properties.totalResults == 0 || results.Count < properties.totalResults))
                {
                    request.PageToken = pagedResult.NextPageToken;
                    properties.updateProgressBar(5, 10, "Gathering " + resultObjType,
                            string.Format("-Collecting {0} {1} to {2}",
                                resultObjType,
                                (results.Count + 1).ToString(),
                                (results.Count + request.MaxResults).ToString()));
                    pagedResult = request.Execute();
                    results.AddRange(pagedResult.Mobiledevices);
                }

                properties.updateProgressBar(1, 2, "Gathering " + resultObjType,
                        string.Format("-Returning {0} results.", results.Count.ToString()));

                return results;
            }
        }
        #endregion

        #region Orgunits
        public class Orgunits
        {
            public class OrgunitsListProperties
            {
                public string orgUnitPath=null;
                public directory_v1.OrgunitsResource.ListRequest.TypeEnum? type=null;
            }
            public static string Delete(string customerId, Google.Apis.Util.Repeatable<string> orgUnitPath)
            {
                return services[activeDomain].Orgunits.Delete(customerId, orgUnitPath).Execute();
            }

            public static Data.OrgUnit Get(string customerId, Google.Apis.Util.Repeatable<string> orgUnitPath)
            {
                return services[activeDomain].Orgunits.Get(customerId, orgUnitPath).Execute();
            }

            public static Data.OrgUnit Insert(Data.OrgUnit body, string customerId)
            {
                return services[activeDomain].Orgunits.Insert(body, customerId).Execute();
            }

            public static List<Data.OrgUnit> List(string customerId, OrgunitsListProperties properties = null)
            {
                List<Data.OrgUnit> results = new List<Data.OrgUnit>();

                directory_v1.OrgunitsResource.ListRequest request =
                    services[activeDomain].Orgunits.List(customerId);

                if (null != properties)
                {
                    request.OrgUnitPath = properties.orgUnitPath;
                    request.Type = properties.type;
                }

                Data.OrgUnits pagedResult = request.Execute();

                results.AddRange(pagedResult.OrganizationUnits);

                return results;
            }

            public static Data.OrgUnit Patch(Data.OrgUnit body, string customerId, Google.Apis.Util.Repeatable<string> orgUnitPath)
            {
                return services[activeDomain].Orgunits.Patch(body, customerId, orgUnitPath).Execute();
            }

            public static Data.OrgUnit Update(Data.OrgUnit body, string customerId, Google.Apis.Util.Repeatable<string> orgUnitPath)
            {
                return services[activeDomain].Orgunits.Update(body, customerId, orgUnitPath).Execute();
            }
        }
        #endregion

        #region Users
        public class Users
        {
            public class UsersListProperties
            {
                public string customer = null;
                public string domain = null;
                public string fields = null;
                public int maxResults = 100;
                public string query = null;
                public bool showDeleted = false;
                public directory_v1.UsersResource.ListRequest.OrderByEnum? orderBy = null;
                public directory_v1.UsersResource.ListRequest.SortOrderEnum? sortOrder = null;
                public directory_v1.UsersResource.ListRequest.ViewTypeEnum? viewType = null;
                public directory_v1.UsersResource.ListRequest.ProjectionEnum? projection = null;
                public string customFieldMask = null;
                public Action<string, string> startProgressBar = null;
                public Action<int, int, string, string> updateProgressBar = null;
                public int totalResults = 0;
            }

            public static string Delete(string userKey)
            {
                return services[activeDomain].Users.Delete(userKey).Execute();
            }

            public static Data.User Get(string userKey,
                directory_v1.UsersResource.GetRequest.ProjectionEnum? projection = null,
                directory_v1.UsersResource.GetRequest.ViewTypeEnum? viewType = null)
            {
                directory_v1.UsersResource.GetRequest request = 
                    services[activeDomain].Users.Get(userKey);

                request.Projection = projection;
                request.ViewType = viewType;

                return request.Execute();
            }

            public static Data.User Insert(Data.User body)
            {
                return services[activeDomain].Users.Insert(body).Execute();
            }

            public static List<Data.User> List(UsersListProperties properties = null)
            {
                List<Data.User> results = new List<Data.User>();

                directory_v1.UsersResource.ListRequest request =
                    services[activeDomain].Users.List();

                if (null != properties)
                {
                    if (null != properties.projection) { request.CustomFieldMask = properties.customFieldMask; }
                    request.Customer = properties.customer;
                    request.Domain = properties.domain;
                    request.Fields = properties.fields;
                    request.MaxResults = properties.maxResults;
                    request.OrderBy = properties.orderBy;
                    request.Projection = properties.projection;
                    request.Query = properties.query;
                    request.ShowDeleted = properties.showDeleted.ToString().ToLower();
                    request.SortOrder = properties.sortOrder;
                    request.ViewType = properties.viewType;
                }

                string resultObjType = "users";

                properties.startProgressBar("Gathering " + resultObjType,
                    string.Format("-Collecting {0} {1} to {2}", resultObjType, "1", request.MaxResults.ToString()));

                Data.Users pagedResult = request.Execute();

                results.AddRange(pagedResult.UsersValue);

                while (!string.IsNullOrWhiteSpace(pagedResult.NextPageToken) &&
                    pagedResult.NextPageToken != request.PageToken &&
                (properties.totalResults == 0 || results.Count < properties.totalResults))
                {
                    request.PageToken = pagedResult.NextPageToken;
                    properties.updateProgressBar(5, 10, "Gathering " + resultObjType,
                            string.Format("-Collecting {0} {1} to {2}",
                                resultObjType,
                                (results.Count + 1).ToString(),
                                (results.Count + request.MaxResults).ToString()));
                    pagedResult = request.Execute();
                    results.AddRange(pagedResult.UsersValue);
                }

                properties.updateProgressBar(1, 2, "Gathering " + resultObjType,
                        string.Format("-Returning {0} results.", results.Count.ToString()));

                return results;
            }

            public static string MakeAdmin(Data.UserMakeAdmin body, string userKey)
            {
                return services[activeDomain].Users.MakeAdmin(body, userKey).Execute();
            }

            public static Data.User Patch(Data.User body, string userKey)
            {
                return services[activeDomain].Users.Patch(body, userKey).Execute();
            }

            public static string Undelete(Data.UserUndelete body, string userKey)
            {
                return services[activeDomain].Users.Undelete(body, userKey).Execute();
            }

            public static Data.User Update(Data.User body, string userKey)
            {
                return services[activeDomain].Users.Update(body, userKey).Execute();
            }

            public static Data.Channel Watch(Data.Channel body)
            {
                return services[activeDomain].Users.Watch(body).Execute();
            }

            #region Users.aliases
            public class Aliases
            {
                public static string Delete(string userKey, string alias)
                {
                    return services[activeDomain].Users.Aliases.Delete(userKey, alias).Execute();
                }

                public static Data.Alias Insert(Data.Alias body, string userKey)
                {
                    return services[activeDomain].Users.Aliases.Insert(body, userKey).Execute();
                }

                public static List<Data.Alias> List(string userKey)
                {
                    List<Data.Alias> results = new List<Data.Alias>();

                    directory_v1.UsersResource.AliasesResource.ListRequest request =
                        services[activeDomain].Users.Aliases.List(userKey);

                    Data.Aliases pagedResult = request.Execute();

                    results.AddRange(pagedResult.AliasesValue);

                    return results;
                }

                public static Data.Channel Watch(Data.Channel body, string userKey)
                {
                    return services[activeDomain].Users.Aliases.Watch(body, userKey).Execute();
                }
            }
            #endregion

            #region Users.photos
            public class Photos
            {
                public static string Delete(string userKey)
                {
                    return services[activeDomain].Users.Photos.Delete(userKey).Execute();
                }

                public static Data.UserPhoto Get(string userKey)
                {
                    return services[activeDomain].Users.Photos.Get(userKey).Execute();
                }

                public static Data.UserPhoto Patch(Data.UserPhoto body, string userKey)
                {
                    return services[activeDomain].Users.Photos.Patch(body, userKey).Execute();
                }

                public static Data.UserPhoto Update(Data.UserPhoto body, string userKey)
                {
                    return services[activeDomain].Users.Photos.Update(body, userKey).Execute();
                }
            }
            #endregion
        }
        #endregion

        #region Asps
        public class Asps
        {
            public static string Delete(string userKey, int codeId)
            {
                return services[activeDomain].Asps.Delete(userKey, codeId).Execute();
            }

            public static Data.Asp Get(string userKey, int codeId)
            {
                return services[activeDomain].Asps.Get(userKey, codeId).Execute();
            }

            public static List<Data.Asp> List(string userKey)
            {
                List<Data.Asp> results = new List<Data.Asp>();

                directory_v1.AspsResource.ListRequest request =
                    services[activeDomain].Asps.List(userKey);

                Data.Asps pagedResult = request.Execute();

                results.AddRange(pagedResult.Items);

                return results;
            }
        }
        #endregion

        #region Tokens
        public class Tokens
        {
            public static string Delete(string userKey, string clientId)
            {
                return services[activeDomain].Tokens.Delete(userKey, clientId).Execute();
            }

            public static Data.Token Get(string userKey, string clientId)
            {
                return services[activeDomain].Tokens.Get(userKey, clientId).Execute();
            }

            public static List<Data.Token> List(string userKey)
            {
                List<Data.Token> results = new List<Data.Token>();

                directory_v1.TokensResource.ListRequest request =
                    services[activeDomain].Tokens.List(userKey);

                Data.Tokens pagedResult = request.Execute();

                results.AddRange(pagedResult.Items);

                return results;
            }
        }
        #endregion

        #region VerificationCodes
        public class VerificationCodes
        {
            public static string Generate(string userKey)
            {
                return services[activeDomain].VerificationCodes.Generate(userKey).Execute();
            }

            public static string Invalidate(string userKey)
            {
                return services[activeDomain].VerificationCodes.Invalidate(userKey).Execute();
            }

            public static List<Data.VerificationCode> List(string userKey)
            {
                List<Data.VerificationCode> results = new List<Data.VerificationCode>();

                directory_v1.VerificationCodesResource.ListRequest request =
                    services[activeDomain].VerificationCodes.List(userKey);

                Data.VerificationCodes pagedResult = request.Execute();

                results.AddRange(pagedResult.Items);

                return results;
            }
        }
        #endregion

        #region Notifications
        public class Notifications
        {
            public class NotificationsListProperties
            {
                public int maxResults = 100;
                public string language = null;
                public Action<string, string> startProgressBar = null;
                public Action<int, int, string, string> updateProgressBar = null;
                public int totalResults = 0;
            }

            public static string Delete(string customer, string notificationId)
            {
                return services[activeDomain].Notifications.Delete(customer, notificationId).Execute();
            }

            public static Data.Notification Get(string customer, string notificationId)
            {
                return services[activeDomain].Notifications.Get(customer, notificationId).Execute();
            }

            public static List<Data.Notification> List(string customer, NotificationsListProperties properties = null)
            {
                List<Data.Notification> results = new List<Data.Notification>();

                directory_v1.NotificationsResource.ListRequest request =
                    services[activeDomain].Notifications.List(customer);

                if (null != properties)
                {
                    request.Language = properties.language;
                    request.MaxResults = properties.maxResults;
                }

                string resultObjType = "notifications";

                properties.startProgressBar("Gathering " + resultObjType,
                    string.Format("-Collecting {0} {1} to {2}", resultObjType, "1", request.MaxResults.ToString()));

                Data.Notifications pagedResult = request.Execute();

                results.AddRange(pagedResult.Items);

                while (!string.IsNullOrWhiteSpace(pagedResult.NextPageToken) &&
                    pagedResult.NextPageToken != request.PageToken &&
                (properties.totalResults == 0 || results.Count < properties.totalResults))
                {
                    request.PageToken = pagedResult.NextPageToken;
                    properties.updateProgressBar(5, 10, "Gathering " + resultObjType,
                            string.Format("-Collecting {0} {1} to {2}",
                                resultObjType,
                                (results.Count + 1).ToString(),
                                (results.Count + request.MaxResults).ToString()));
                    pagedResult = request.Execute();
                    results.AddRange(pagedResult.Items);
                }

                properties.updateProgressBar(1, 2, "Gathering " + resultObjType,
                        string.Format("-Returning {0} results.", results.Count.ToString()));

                return results;
            }

            public static Data.Notification Patch(Data.Notification body, string customer, string notificationId)
            {
                return services[activeDomain].Notifications.Patch(body, customer, notificationId).Execute();
            }

            public static Data.Notification Update(Data.Notification body, string customer, string notificationId)
            {
                return services[activeDomain].Notifications.Update(body, customer, notificationId).Execute();
            }
        }
        #endregion

        #region Channels
        public class Channels
        {
            public static string Stop(Data.Channel body)
            {
                return services[activeDomain].Channels.Stop(body).Execute();
            }
        }
        #endregion

        #region Schemas
        public class Schemas
        {
            public static string Delete(string customerId, string schemaKey)
            {
                return services[activeDomain].Schemas.Delete(customerId, schemaKey).Execute();
            }

            public static Data.Schema Get(string customerId, string schemaKey)
            {
                return services[activeDomain].Schemas.Get(customerId, schemaKey).Execute();
            }

            public static Data.Schema Insert(Data.Schema body, string customerId)
            {
                return services[activeDomain].Schemas.Insert(body, customerId).Execute();
            }

            public static List<Data.Schema> List(string customerId)
            {
                List<Data.Schema> results = new List<Data.Schema>();

                directory_v1.SchemasResource.ListRequest request =
                    services[activeDomain].Schemas.List(customerId);

                Data.Schemas pagedResult = request.Execute();

                results.AddRange(pagedResult.SchemasValue);

                return results;
            }

            public static Data.Schema Patch(Data.Schema body, string customerId, string schemaKey)
            {
                return services[activeDomain].Schemas.Patch(body, customerId, schemaKey).Execute();
            }

            public static Data.Schema Update(Data.Schema body, string customerId, string schemaKey)
            {
                return services[activeDomain].Schemas.Update(body, customerId, schemaKey).Execute();
            }
        }
        #endregion

        //end of wrapped methods
        #endregion
    }
}
