using Android.Views;
using Android.Widget;
using AndroidX.RecyclerView.Widget;

namespace Noten.ViewsHolders
{
    public class ReceiverViewHolder : RecyclerView.ViewHolder
    {
        public TextView received { get; private set; }

        public ReceiverViewHolder(View itemView) : base(itemView)
        {
            received = (TextView) itemView.FindViewById(Resource.Id.txt_viw_received);
        }

        public void ReceiverData(View itemView)
        {
            received = (TextView) itemView.FindViewById(Resource.Id.txt_viw_received);
        }
    }
}