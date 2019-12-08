using Amazon;
using Amazon.EC2;
using Amazon.RDS;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AwsInstanceManager
{
    public class InstanceManager
    {
        private readonly string ACCESS_KEY;
        private readonly string SECRET;
        private readonly string REGION;
        AmazonEC2Client _EC2Client;
        AmazonRDSClient _RDSClient;
        RDSManager RDSManager { get; set; }
        public InstanceManager(string ACCESS_KEY, string SECRET, string REGION)
        {
            this.ACCESS_KEY = ACCESS_KEY;
            this.SECRET = SECRET;
            this.REGION = REGION;
            Amazon.Runtime.BasicAWSCredentials credentials = new Amazon.Runtime.BasicAWSCredentials(ACCESS_KEY, SECRET);
            RegionEndpoint region = RegionEndpoint.GetBySystemName(this.REGION);
            _EC2Client = new AmazonEC2Client(credentials, region);
            _RDSClient = new AmazonRDSClient(credentials, region);
        }
        public async Task<bool> Start(string instanceName, InstanceType instanceType)
        {
            switch (instanceType)
            {
                case InstanceType.EC2:
                    {
                        try
                        {
                            List<string> instances = new List<string>() { instanceName };
                            EC2Manager eC2Manager = new EC2Manager(_EC2Client);
                            await eC2Manager.StartInstance(instances);
                            return true;
                        }
                        catch (Exception ex)
                        {
                            return false;
                        }
                    }
                    break;
                case InstanceType.RDS:
                    {
                        try
                        {
                            RDSManager rDSManager = new RDSManager(_RDSClient);
                            await rDSManager.StartInstance(instanceName);
                            return true;
                        }
                        catch (Exception ex)
                        {
                            return false;
                        }
                    }
                    break;
            }
            return false;
        }

        public async Task<bool> Stop(string instanceName, InstanceType instanceType)
        {
            switch (instanceType)
            {
                case InstanceType.EC2:
                    {
                        try
                        {
                            List<string> instances = new List<string>() { instanceName };
                            EC2Manager eC2Manager = new EC2Manager(_EC2Client);
                            await eC2Manager.StopInstance(instances);
                            return true;
                        }
                        catch (Exception ex)
                        {
                            return false;
                        }
                    }
                    break;
                case InstanceType.RDS:
                    {
                        try
                        {
                            RDSManager rDSManager = new RDSManager(_RDSClient);
                            await rDSManager.StopInstance(instanceName);
                            return true;
                        }
                        catch (Exception ex)
                        {
                            return false;
                        }
                    }
                    break;
            }
            return false;
        }

    }
    public enum InstanceType
    {
        EC2,
        RDS
    }

}
