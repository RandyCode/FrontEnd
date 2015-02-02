
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontendCore
{
    [HubName("chathub")]
    public class ChatHub:Hub
    {
        public void SendAll(string sender, string message)
        {
            //所有连接的客户端
            Clients.All.broadcastMessage(sender, message);

            //接受信息对象
            //Clients.Client(Context.ConnectionId) //指定客户端
            //Clients.Others  //除了调用的客户端
            //Clients.Client //仅调用的客户端
            //Clients.Group(groupname).broadcastMessage();
        }

        public void SendUser(string[] userId, string sender, string message)
        {
            Clients.Users(userId.ToList()).broadcastMessage(sender,message);
        }

        public void SendGroup(string[] groupName, string sender, string message)
        {
            Clients.Groups(groupName.ToList()).broadcastMessage(sender, message);
        }

        public Task JoinGroup(string groupName)
        {
            return Groups.Add(Context.ConnectionId, groupName);
        }

        public Task LeaveGroup(string groupName)
        {
            return Groups.Remove(Context.ConnectionId, groupName);
        }
    
    }
}
