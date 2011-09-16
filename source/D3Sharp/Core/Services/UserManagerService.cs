﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using D3Sharp.Net;
using D3Sharp.Net.Packets;

namespace D3Sharp.Core.Services
{
    [Service(serviceID: 0x5, serverHash: 0x3E19268A, clientHash: 0xBC872C22)]
    public class UserManagerService : Service
    {
        [ServiceMethod(0x1)]
        public void SubscribeToUserManager(IClient client, Packet packetIn)
        {
            var response = bnet.protocol.user_manager.SubscribeToUserManagerResponse.CreateBuilder().Build();

            var packet = new Packet(
                new Header(0xfe, 0x0, packetIn.Header.RequestID, (uint)response.SerializedSize),
                response.ToByteArray());

            Logger.Debug("RPC:UserManager:Subscribe()");
            client.Send(packet);
        }
    }
}
