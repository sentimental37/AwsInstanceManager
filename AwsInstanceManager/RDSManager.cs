using Amazon.EC2.Model;
using Amazon.RDS;
using Amazon.RDS.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AwsInstanceManager
{
    internal class RDSManager
    {
        AmazonRDSClient client;
        public RDSManager(AmazonRDSClient client)
        {
            this.client = client;
        }
        public async Task StopInstance(string instance)
        {
            try
            {
                StopDBInstanceResponse response = await this.client.StopDBInstanceAsync(new StopDBInstanceRequest
                {
                    DBInstanceIdentifier = instance
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<StartDBInstanceResponse> StartInstance(string instance)
        {
            try
            {
                StartDBInstanceResponse response = await this.client.StartDBInstanceAsync(new StartDBInstanceRequest
                {
                    DBInstanceIdentifier = instance
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
