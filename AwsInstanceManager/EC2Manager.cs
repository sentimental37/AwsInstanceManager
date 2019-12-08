using Amazon.EC2;
using Amazon.EC2.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AwsInstanceManager
{
    internal class EC2Manager
    {
        AmazonEC2Client client;
        public EC2Manager(AmazonEC2Client client)
        {
            this.client = client;
        }
        public async Task StopInstance(List<string> instances)
        {
            try
            {
                StopInstancesResponse response = await this.client.StopInstancesAsync(new StopInstancesRequest
                {
                    InstanceIds = instances
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<StartInstancesResponse> StartInstance(List<string> instances)
        {
            try
            {
                StartInstancesResponse response = await this.client.StartInstancesAsync(new StartInstancesRequest
                {
                    InstanceIds = instances
                });

                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
