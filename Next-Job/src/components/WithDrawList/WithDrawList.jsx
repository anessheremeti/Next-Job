import WithdrawItem from '../WithDrawItem/WithDrawItem';
const WithdrawList = () => {
    return (
      <div className=" ">
        <div className="activity_title flex gap-48">
          <p>Recent Withdrawals</p>
          <button type="button" className="bg-gray-200 px-4">
            Clear All
          </button>
        </div>
  
        
        <WithdrawItem
          taskName="$212 Withdrawed to Engjell Ajeti"
          
          timeAgo="1 week ago"
        />
        <WithdrawItem
          taskName="$212 Withdrawed to Engjell Ajeti"
         
          timeAgo="1 week ago"
        />
        <WithdrawItem
          taskName="$212 Withdrawed to Engjell Ajeti"
         
          timeAgo="1 week ago"
        />
      </div>
    );
  };
  export default WithdrawList;