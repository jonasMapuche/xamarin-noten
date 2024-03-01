
using Android.Views;
using AndroidX.RecyclerView.Widget;
using Noten.Models;
using Noten.ViewsHolders;
using System.Collections.Generic;

namespace Noten.Adapters
{
    public class BotAdapter : RecyclerView.Adapter
    {
        private List<MessageModel> message;
        public int VIEW_TYPE_SEND = 1;
        public int VIEW_TYPE_RECEIVED = 2;

        public BotAdapter(List<MessageModel> message)
        {
            this.message = message;
        }

        public override int GetItemViewType(int position)
        {
            if (message[position].sender.Equals(VIEW_TYPE_SEND)) return VIEW_TYPE_SEND;
            else return VIEW_TYPE_RECEIVED;
        }

        public override int ItemCount
        {
            get { return message.Count; }
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            if (GetItemViewType(position) == VIEW_TYPE_RECEIVED)
            {
                ReceiverViewHolder receive_holder = holder as ReceiverViewHolder;
                receive_holder.received.Text = message[position].text;
            }
            else
            {
                SendViewHolder send_holder = holder as SendViewHolder;
                send_holder.send.Text = message[position].text;
            }
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            if (viewType == VIEW_TYPE_RECEIVED)
            {
                View item_view_receiver = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.content_received_message, parent, false);
                ReceiverViewHolder view_holder_receiver = new ReceiverViewHolder(item_view_receiver);
                return view_holder_receiver;
            }
            else
            {
                View item_view_send = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.content_send_message, parent, false);
                SendViewHolder view_holder_send = new SendViewHolder(item_view_send);
                return view_holder_send;
            }
        }
    }
}