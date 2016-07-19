// gShell is licensed under the GNU GENERAL PUBLIC LICENSE, Version 3
//
// http://www.gnu.org/licenses/gpl-3.0.en.html
//
// Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on
// an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the License for the
// specific language governing permissions and limitations under the License.
//
// gShell is based upon https://github.com/google/google-api-dotnet-client, which is licensed under the Apache 2.0
// license: https://github.com/google/google-api-dotnet-client/blob/master/LICENSE
//
// gShell is reliant upon the Google Apis. Please see the specific API pages for specific licensing information.

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a fork of google-apis-code-generator:
//       https://github.com/squid808/apis-client-generator
//
//     How neat is that? Pretty neat.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace gShell.Cmdlets.Reseller{

    using System;
    using System.Collections.Generic;
    using System.Management.Automation;

    using Google.Apis.Auth.OAuth2;
    using Google.Apis.Services;
    using v1 = Google.Apis.Reseller.v1;
    using Data = Google.Apis.Reseller.v1.Data;

    using gShell.dotNet.Utilities;
    using gShell.dotNet.Utilities.OAuth2;
    using gReseller = gShell.dotNet.Reseller;

    /// <summary>
    /// A PowerShell-ready wrapper for the Reseller api, as well as the resources and methods therein.
    /// </summary>
    public abstract class ResellerBase : OAuth2CmdletBase
    {

        #region Properties

        /// <summary>
        /// <para type="description">The domain against which this cmdlet should run.</para>
        /// </summary>
        [Parameter(Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string Domain { get; set; }

        /// <summary>The gShell dotNet class wrapper base.</summary>
        protected static gReseller mainBase { get; set; }


        /// <summary>An instance of the Customers gShell dotNet resource.</summary>
        public Customers customers { get; set; }

        /// <summary>An instance of the Subscriptions gShell dotNet resource.</summary>
        public Subscriptions subscriptions { get; set; }

        /// <summary>Returns the api name and version in {name}:{version} format.</summary>
        protected override string apiNameAndVersion { get { return mainBase.apiNameAndVersion; } }

        /// <summary>Gets or sets the email account the gShell Service Account should impersonate.</summary>
        protected static string gShellServiceAccount { get; set; }
        #endregion

        #region Constructors
        protected ResellerBase()
        {
            mainBase = new gReseller();

            customers = new Customers();
            subscriptions = new Subscriptions();
        }
        #endregion

        #region PowerShell Methods
        /// <summary>The gShell base implementation of the PowerShell BeginProcessing method.</summary>
        /// <remarks>If a service account needs to be identified, it should be in a child class that overrides
        /// and calls this method.</remarks>
        protected override void BeginProcessing()
        {
            var secrets = CheckForClientSecrets();
            if (secrets != null)
            {
                IEnumerable<string> scopes = EnsureScopesExist(Domain);
                Domain = mainBase.BuildService(Authenticate(scopes, secrets, Domain), gShellServiceAccount).domain;

                GWriteProgress = new gWriteProgress(WriteProgress);
            }
            else
            {
                WriteError(new ErrorRecord(null, (new Exception(
                    "Client Secrets must be set before running cmdlets. Run 'Get-Help "
                    + "Set-gShellClientSecrets -online' for more information."))));
            }
        }

        /// <summary>The gShell base implementation of the PowerShell EndProcessing method.</summary>
        /// <remarks>We need to reset the service account after every Cmdlet call to prevent the next
        /// Cmdlet from inheriting it as well.</remarks>
        protected override void EndProcessing()
        {
            gShellServiceAccount = string.Empty;
        }

        /// <summary>The gShell base implementation of the PowerShell StopProcessing method.</summary>
        /// <remarks>We need to reset the service account after every Cmdlet call to prevent the next
        /// Cmdlet from inheriting it as well.</remarks>
        protected override void StopProcessing()
        {
            gShellServiceAccount = string.Empty;
        }
        #endregion

        #region Authentication & Processing
        /// <summary>Ensure the user, domain and client secret combination work with an authenticated user.</summary>
        /// <param name="Scopes">The scopes that need to be passed through to the user authentication to Google.</param>
        /// <param name="Secrets">The client secrets.`</param>
        /// <param name="Domain">The domain for which this authentication is intended.</param>
        /// <returns>The AuthenticatedUserInfo for the authenticated user.</returns>
        protected override AuthenticatedUserInfo Authenticate(IEnumerable<string> Scopes, ClientSecrets Secrets, string Domain = null)
        {
            return mainBase.Authenticate(apiNameAndVersion, Scopes, Secrets, Domain);
        }
        #endregion

        #region Wrapped Methods



        #region Customers

        /// <summary>A wrapper class for the Customers resource.</summary>
        public class Customers
        {




            /// <summary>Gets a customer resource if one exists and is owned by the reseller.</summary>
            /// <param name="CustomerId">Id of the Customer</param>
            public Google.Apis.Reseller.v1.Data.Customer Get (string CustomerId)
            {

                return mainBase.customers.Get(CustomerId, gShellServiceAccount);
            }



            /// <summary>Creates a customer resource if one does not already exist.</summary>
            /// <param name="CustomerBody">The body of the request.</param>
            /// <param name="properties">The optional properties for this method.</param>
            public Google.Apis.Reseller.v1.Data.Customer Insert (Google.Apis.Reseller.v1.Data.Customer CustomerBody, gReseller.Customers.CustomersInsertProperties properties= null)
            {

                properties = properties ?? new gReseller.Customers.CustomersInsertProperties();

                return mainBase.customers.Insert(CustomerBody, properties, gShellServiceAccount);
            }



            /// <summary>Update a customer resource if one it exists and is owned by the reseller. This method supports
            /// patch semantics.</summary>
            /// <param name="CustomerBody">The body of the request.</param>
            /// <param name="CustomerId">Id of the Customer</param>
            public Google.Apis.Reseller.v1.Data.Customer Patch (Google.Apis.Reseller.v1.Data.Customer CustomerBody, string CustomerId)
            {

                return mainBase.customers.Patch(CustomerBody, CustomerId, gShellServiceAccount);
            }



            /// <summary>Update a customer resource if one it exists and is owned by the reseller.</summary>
            /// <param name="CustomerBody">The body of the request.</param>
            /// <param name="CustomerId">Id of the Customer</param>
            public Google.Apis.Reseller.v1.Data.Customer Update (Google.Apis.Reseller.v1.Data.Customer CustomerBody, string CustomerId)
            {

                return mainBase.customers.Update(CustomerBody, CustomerId, gShellServiceAccount);
            }


        }
        #endregion



        #region Subscriptions

        /// <summary>A wrapper class for the Subscriptions resource.</summary>
        public class Subscriptions
        {




            /// <summary>Activates a subscription previously suspended by the reseller</summary>
            /// <param name="CustomerId">Id of the Customer</param>
            /// <param name="SubscriptionId">Id of the subscription,
            /// which is unique for a customer</param>
            public Google.Apis.Reseller.v1.Data.Subscription Activate (string CustomerId, string SubscriptionId)
            {

                return mainBase.subscriptions.Activate(CustomerId, SubscriptionId, gShellServiceAccount);
            }



            /// <summary>Changes the plan of a subscription</summary>
            /// <param name="ChangePlanRequestBody">The body of the request.</param>
            /// <param name="CustomerId">Id of the Customer</param>
            /// <param name="SubscriptionId">Id of the subscription,
            /// which is unique for a customer</param>
            public Google.Apis.Reseller.v1.Data.Subscription ChangePlan (Google.Apis.Reseller.v1.Data.ChangePlanRequest ChangePlanRequestBody, string CustomerId, string SubscriptionId)
            {

                return mainBase.subscriptions.ChangePlan(ChangePlanRequestBody, CustomerId, SubscriptionId, gShellServiceAccount);
            }



            /// <summary>Changes the renewal settings of a subscription</summary>
            /// <param name="RenewalSettingsBody">The body of the request.</param>
            /// <param name="CustomerId">Id of the Customer</param>
            /// <param name="SubscriptionId">Id of the subscription,
            /// which is unique for a customer</param>
            public Google.Apis.Reseller.v1.Data.Subscription ChangeRenewalSettings (Google.Apis.Reseller.v1.Data.RenewalSettings RenewalSettingsBody, string CustomerId, string SubscriptionId)
            {

                return mainBase.subscriptions.ChangeRenewalSettings(RenewalSettingsBody, CustomerId, SubscriptionId, gShellServiceAccount);
            }



            /// <summary>Changes the seats configuration of a subscription</summary>
            /// <param name="SeatsBody">The body of the request.</param>
            /// <param name="CustomerId">Id of the Customer</param>
            /// <param name="SubscriptionId">Id of the subscription,
            /// which is unique for a customer</param>
            public Google.Apis.Reseller.v1.Data.Subscription ChangeSeats (Google.Apis.Reseller.v1.Data.Seats SeatsBody, string CustomerId, string SubscriptionId)
            {

                return mainBase.subscriptions.ChangeSeats(SeatsBody, CustomerId, SubscriptionId, gShellServiceAccount);
            }



            /// <summary>Cancels/Downgrades a subscription.</summary>
            /// <param name="CustomerId">Id of the Customer</param>
            /// <param name="SubscriptionId">Id of the subscription,
            /// which is unique for a customer</param>
            /// <param name="DeletionType">Whether the subscription is to be fully
            /// cancelled or downgraded</param>
            public void Delete (string CustomerId, string SubscriptionId, v1.SubscriptionsResource.DeleteRequest.DeletionTypeEnum DeletionType)
            {

                mainBase.subscriptions.Delete(CustomerId, SubscriptionId, DeletionType, gShellServiceAccount);
            }



            /// <summary>Gets a subscription of the customer.</summary>
            /// <param name="CustomerId">Id of the Customer</param>
            /// <param name="SubscriptionId">Id of the subscription,
            /// which is unique for a customer</param>
            public Google.Apis.Reseller.v1.Data.Subscription Get (string CustomerId, string SubscriptionId)
            {

                return mainBase.subscriptions.Get(CustomerId, SubscriptionId, gShellServiceAccount);
            }



            /// <summary>Creates/Transfers a subscription for the customer.</summary>
            /// <param name="SubscriptionBody">The body of the request.</param>
            /// <param name="CustomerId">Id of the Customer</param>
            /// <param name="properties">The optional properties for this method.</param>
            public Google.Apis.Reseller.v1.Data.Subscription Insert (Google.Apis.Reseller.v1.Data.Subscription SubscriptionBody, string CustomerId, gReseller.Subscriptions.SubscriptionsInsertProperties properties= null)
            {

                properties = properties ?? new gReseller.Subscriptions.SubscriptionsInsertProperties();

                return mainBase.subscriptions.Insert(SubscriptionBody, CustomerId, properties, gShellServiceAccount);
            }



            /// <summary>Lists subscriptions of a reseller, optionally filtered by a customer name prefix.</summary>
            /// <param name="properties">The optional properties for this method.</param>

            public List<Google.Apis.Reseller.v1.Data.Subscriptions> List(gReseller.Subscriptions.SubscriptionsListProperties properties= null)
            {

                properties = properties ?? new gReseller.Subscriptions.SubscriptionsListProperties();
                properties.StartProgressBar = StartProgressBar;
                properties.UpdateProgressBar = UpdateProgressBar;

                return mainBase.subscriptions.List(properties, gShellServiceAccount);
            }

            /// <summary>Starts paid service of a trial subscription</summary>
            /// <param name="CustomerId">Id of the Customer</param>
            /// <param name="SubscriptionId">Id of the subscription,
            /// which is unique for a customer</param>
            public Google.Apis.Reseller.v1.Data.Subscription StartPaidService (string CustomerId, string SubscriptionId)
            {

                return mainBase.subscriptions.StartPaidService(CustomerId, SubscriptionId, gShellServiceAccount);
            }



            /// <summary>Suspends an active subscription</summary>
            /// <param name="CustomerId">Id of the Customer</param>
            /// <param name="SubscriptionId">Id of the subscription,
            /// which is unique for a customer</param>
            public Google.Apis.Reseller.v1.Data.Subscription Suspend (string CustomerId, string SubscriptionId)
            {

                return mainBase.subscriptions.Suspend(CustomerId, SubscriptionId, gShellServiceAccount);
            }


        }
        #endregion

        #endregion

    }
}



namespace gShell.dotNet
{
    using System;
    using System.Collections.Generic;

    using gShell.dotNet;
    using gShell.dotNet.Utilities.OAuth2;

    using v1 = Google.Apis.Reseller.v1;
    using Data = Google.Apis.Reseller.v1.Data;

    /// <summary>The dotNet gShell version of the reseller api.</summary>
    public class Reseller : ServiceWrapper<v1.ResellerService>
    {

        protected override bool worksWithGmail { get { return true; } }

        /// <summary>Creates a new v1.Reseller service.</summary>
        /// <param name="domain">The domain to which this service will be authenticated.</param>
        /// <param name="authInfo">The authenticated AuthInfo for this user and domain.</param>
        /// <param name="gShellServiceAccount">The optional email address the service account should impersonate.</param>

        protected override v1.ResellerService CreateNewService(string domain, AuthenticatedUserInfo authInfo, string gShellServiceAccount = null)
        {
            return new v1.ResellerService(OAuth2Base.GetInitializer(domain, authInfo, gShellServiceAccount));
        }

        /// <summary>Returns the api name and version in {name}:{version} format.</summary>
        public override string apiNameAndVersion { get { return "reseller:v1"; } }


        /// <summary>Gets or sets the customers resource class.</summary>
        public Customers customers{ get; set; }

        /// <summary>Gets or sets the subscriptions resource class.</summary>
        public Subscriptions subscriptions{ get; set; }

        public Reseller()
        {

            customers = new Customers();
            subscriptions = new Subscriptions();
        }



        /// <summary>The "customers" collection of methods.</summary>
        public class Customers
        {

            /// <summary>Optional parameters for the Customers Insert method.</summary>
            public class CustomersInsertProperties
            {
                /// <summary>An auth token needed for inserting a customer for which domain already exists. Can be generated at https://admin.google.com/TransferToken. Optional.</summary>
                public string CustomerAuthToken = null;
            }


            /// <summary>Gets a customer resource if one exists and is owned by the reseller.</summary>
            /// <param name="CustomerId">Id of the Customer</param>
            /// <param name="gShellServiceAccount">The optional email address the service account should impersonate.</param>
            public Google.Apis.Reseller.v1.Data.Customer Get (string CustomerId, string gShellServiceAccount = null)
            {
                return GetService(gShellServiceAccount).Customers.Get(CustomerId).Execute();
            }

            /// <summary>Creates a customer resource if one does not already exist.</summary>
            /// <param name="CustomerBody">The body of the request.</param>
            /// <param name="properties">The optional properties for this method.</param>
            /// <param name="gShellServiceAccount">The optional email address the service account should impersonate.</param>
            public Google.Apis.Reseller.v1.Data.Customer Insert (Google.Apis.Reseller.v1.Data.Customer CustomerBody, CustomersInsertProperties properties= null, string gShellServiceAccount = null)
            {
                return GetService(gShellServiceAccount).Customers.Insert(CustomerBody).Execute();
            }

            /// <summary>Update a customer resource if one it exists and is owned by the reseller. This method supports
            /// patch semantics.</summary>
            /// <param name="CustomerBody">The body of the request.</param>
            /// <param name="CustomerId">Id of the Customer</param>
            /// <param name="gShellServiceAccount">The optional email address the service account should impersonate.</param>
            public Google.Apis.Reseller.v1.Data.Customer Patch (Google.Apis.Reseller.v1.Data.Customer CustomerBody, string CustomerId, string gShellServiceAccount = null)
            {
                return GetService(gShellServiceAccount).Customers.Patch(CustomerBody, CustomerId).Execute();
            }

            /// <summary>Update a customer resource if one it exists and is owned by the reseller.</summary>
            /// <param name="CustomerBody">The body of the request.</param>
            /// <param name="CustomerId">Id of the Customer</param>
            /// <param name="gShellServiceAccount">The optional email address the service account should impersonate.</param>
            public Google.Apis.Reseller.v1.Data.Customer Update (Google.Apis.Reseller.v1.Data.Customer CustomerBody, string CustomerId, string gShellServiceAccount = null)
            {
                return GetService(gShellServiceAccount).Customers.Update(CustomerBody, CustomerId).Execute();
            }

        }

        /// <summary>The "subscriptions" collection of methods.</summary>
        public class Subscriptions
        {

            /// <summary>Optional parameters for the Subscriptions Insert method.</summary>
            public class SubscriptionsInsertProperties
            {
                /// <summary>An auth token needed for transferring a subscription. Can be generated at https://www.google.com/a/cpanel/customer-domain/TransferToken. Optional.</summary>
                public string CustomerAuthToken = null;
            }

            /// <summary>Optional parameters for the Subscriptions List method.</summary>
            public class SubscriptionsListProperties
            {
                /// <summary>An auth token needed if the customer is not a resold customer of this reseller. Can be generated at https://www.google.com/a/cpanel/customer-domain/TransferToken.Optional.</summary>
                public string CustomerAuthToken = null;

                /// <summary>Id of the Customer</summary>
                public string CustomerId = null;

                /// <summary>Prefix of the customer's domain name by which the subscriptions should be filtered. Optional</summary>
                public string CustomerNamePrefix = null;

                /// <summary>Maximum number of results to return</summary>
                public int MaxResults = 100;

                /// <summary>A delegate that is used to start a progress bar.</summary>
                public Action<string, string> StartProgressBar = null;

                /// <summary>A delegate that is used to update a progress bar.</summary>
                public Action<int, int, string, string> UpdateProgressBar = null;

                /// <summary>A counter for the total number of results to pull when iterating through paged results.</summary>
                public int TotalResults = 0;
            }


            /// <summary>Activates a subscription previously suspended by the reseller</summary>
            /// <param name="CustomerId">Id of the Customer</param>
            /// <param name="SubscriptionId">Id of the subscription,
            /// which is unique for a customer</param>
            /// <param name="gShellServiceAccount">The optional email address the service account should impersonate.</param>
            public Google.Apis.Reseller.v1.Data.Subscription Activate (string CustomerId, string SubscriptionId, string gShellServiceAccount = null)
            {
                return GetService(gShellServiceAccount).Subscriptions.Activate(CustomerId, SubscriptionId).Execute();
            }

            /// <summary>Changes the plan of a subscription</summary>
            /// <param name="ChangePlanRequestBody">The body of the request.</param>
            /// <param name="CustomerId">Id of the Customer</param>
            /// <param name="SubscriptionId">Id of the subscription,
            /// which is unique for a customer</param>
            /// <param name="gShellServiceAccount">The optional email address the service account should impersonate.</param>
            public Google.Apis.Reseller.v1.Data.Subscription ChangePlan (Google.Apis.Reseller.v1.Data.ChangePlanRequest ChangePlanRequestBody, string CustomerId, string SubscriptionId, string gShellServiceAccount = null)
            {
                return GetService(gShellServiceAccount).Subscriptions.ChangePlan(ChangePlanRequestBody, CustomerId, SubscriptionId).Execute();
            }

            /// <summary>Changes the renewal settings of a subscription</summary>
            /// <param name="RenewalSettingsBody">The body of the request.</param>
            /// <param name="CustomerId">Id of the Customer</param>
            /// <param name="SubscriptionId">Id of the subscription,
            /// which is unique for a customer</param>
            /// <param name="gShellServiceAccount">The optional email address the service account should impersonate.</param>
            public Google.Apis.Reseller.v1.Data.Subscription ChangeRenewalSettings (Google.Apis.Reseller.v1.Data.RenewalSettings RenewalSettingsBody, string CustomerId, string SubscriptionId, string gShellServiceAccount = null)
            {
                return GetService(gShellServiceAccount).Subscriptions.ChangeRenewalSettings(RenewalSettingsBody, CustomerId, SubscriptionId).Execute();
            }

            /// <summary>Changes the seats configuration of a subscription</summary>
            /// <param name="SeatsBody">The body of the request.</param>
            /// <param name="CustomerId">Id of the Customer</param>
            /// <param name="SubscriptionId">Id of the subscription,
            /// which is unique for a customer</param>
            /// <param name="gShellServiceAccount">The optional email address the service account should impersonate.</param>
            public Google.Apis.Reseller.v1.Data.Subscription ChangeSeats (Google.Apis.Reseller.v1.Data.Seats SeatsBody, string CustomerId, string SubscriptionId, string gShellServiceAccount = null)
            {
                return GetService(gShellServiceAccount).Subscriptions.ChangeSeats(SeatsBody, CustomerId, SubscriptionId).Execute();
            }

            /// <summary>Cancels/Downgrades a subscription.</summary>
            /// <param name="CustomerId">Id of the Customer</param>
            /// <param name="SubscriptionId">Id of the subscription,
            /// which is unique for a customer</param>
            /// <param name="DeletionType">Whether the subscription is to be fully
            /// cancelled or downgraded</param>
            /// <param name="gShellServiceAccount">The optional email address the service account should impersonate.</param>
            public void Delete (string CustomerId, string SubscriptionId, v1.SubscriptionsResource.DeleteRequest.DeletionTypeEnum DeletionType, string gShellServiceAccount = null)
            {
                GetService(gShellServiceAccount).Subscriptions.Delete(CustomerId, SubscriptionId, DeletionType).Execute();
            }

            /// <summary>Gets a subscription of the customer.</summary>
            /// <param name="CustomerId">Id of the Customer</param>
            /// <param name="SubscriptionId">Id of the subscription,
            /// which is unique for a customer</param>
            /// <param name="gShellServiceAccount">The optional email address the service account should impersonate.</param>
            public Google.Apis.Reseller.v1.Data.Subscription Get (string CustomerId, string SubscriptionId, string gShellServiceAccount = null)
            {
                return GetService(gShellServiceAccount).Subscriptions.Get(CustomerId, SubscriptionId).Execute();
            }

            /// <summary>Creates/Transfers a subscription for the customer.</summary>
            /// <param name="SubscriptionBody">The body of the request.</param>
            /// <param name="CustomerId">Id of the Customer</param>
            /// <param name="properties">The optional properties for this method.</param>
            /// <param name="gShellServiceAccount">The optional email address the service account should impersonate.</param>
            public Google.Apis.Reseller.v1.Data.Subscription Insert (Google.Apis.Reseller.v1.Data.Subscription SubscriptionBody, string CustomerId, SubscriptionsInsertProperties properties= null, string gShellServiceAccount = null)
            {
                return GetService(gShellServiceAccount).Subscriptions.Insert(SubscriptionBody, CustomerId).Execute();
            }

            /// <summary>Lists subscriptions of a reseller, optionally filtered by a customer name prefix.</summary>
            /// <param name="properties">The optional properties for this method.</param>
            /// <param name="gShellServiceAccount">The optional email address the service account should impersonate.</param>
            public List<Google.Apis.Reseller.v1.Data.Subscriptions> List(
                SubscriptionsListProperties properties= null, string gShellServiceAccount = null)
            {
                var results = new List<Google.Apis.Reseller.v1.Data.Subscriptions>();

                v1.SubscriptionsResource.ListRequest request = GetService(gShellServiceAccount).Subscriptions.List();

                if (properties != null)
                {
                    request.CustomerAuthToken = properties.CustomerAuthToken;
                    request.CustomerId = properties.CustomerId;
                    request.CustomerNamePrefix = properties.CustomerNamePrefix;
                    request.MaxResults = properties.MaxResults;

                }

                if (null != properties.StartProgressBar)
                {
                    properties.StartProgressBar("Gathering Subscriptions",
                        string.Format("-Collecting Subscriptions 1 to {0}", request.MaxResults.ToString()));
                }

                Google.Apis.Reseller.v1.Data.Subscriptions pagedResult = request.Execute();

                if (pagedResult != null)
                {
                    results.Add(pagedResult);

                    while (!string.IsNullOrWhiteSpace(pagedResult.NextPageToken) &&
                        pagedResult.NextPageToken != request.PageToken &&
                    (properties.TotalResults == 0 || results.Count < properties.TotalResults))
                    {
                        request.PageToken = pagedResult.NextPageToken;

                        if (null != properties.UpdateProgressBar)
                        {
                            properties.UpdateProgressBar(5, 10, "Gathering Subscriptions",
                                    string.Format("-Collecting Subscriptions {0} to {1}",
                                        (results.Count + 1).ToString(),
                                        (results.Count + request.MaxResults).ToString()));
                        }
                        pagedResult = request.Execute();
                        results.Add(pagedResult);
                    }

                    if (null != properties.UpdateProgressBar)
                    {
                        properties.UpdateProgressBar(1, 2, "Gathering Subscriptions",
                                string.Format("-Returning {0} results.", results.Count.ToString()));
                    }
                }

                return results;
            }

            /// <summary>Starts paid service of a trial subscription</summary>
            /// <param name="CustomerId">Id of the Customer</param>
            /// <param name="SubscriptionId">Id of the subscription,
            /// which is unique for a customer</param>
            /// <param name="gShellServiceAccount">The optional email address the service account should impersonate.</param>
            public Google.Apis.Reseller.v1.Data.Subscription StartPaidService (string CustomerId, string SubscriptionId, string gShellServiceAccount = null)
            {
                return GetService(gShellServiceAccount).Subscriptions.StartPaidService(CustomerId, SubscriptionId).Execute();
            }

            /// <summary>Suspends an active subscription</summary>
            /// <param name="CustomerId">Id of the Customer</param>
            /// <param name="SubscriptionId">Id of the subscription,
            /// which is unique for a customer</param>
            /// <param name="gShellServiceAccount">The optional email address the service account should impersonate.</param>
            public Google.Apis.Reseller.v1.Data.Subscription Suspend (string CustomerId, string SubscriptionId, string gShellServiceAccount = null)
            {
                return GetService(gShellServiceAccount).Subscriptions.Suspend(CustomerId, SubscriptionId).Execute();
            }

        }

    }
}