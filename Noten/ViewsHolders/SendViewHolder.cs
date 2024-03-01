using Android.Views;
using Android.Widget;
using AndroidX.RecyclerView.Widget;

namespace Noten.ViewsHolders
{
    public class SendViewHolder : RecyclerView.ViewHolder
    {
        public TextView send { get; private set; }

        public SendViewHolder(View itemView) : base(itemView)
        {
            send = (TextView) itemView.FindViewById(Resource.Id.txt_viw_send);
        }

        public void SendData(View itemView)
        {
            send = (TextView) itemView.FindViewById(Resource.Id.txt_viw_send);
        }
    }
}