import cross from '../../src/assets/Background.png';
import ActivityItem from '../ActivityItem/ActivityItem';
import trash from '../../src/assets/Icon (3).png';
const ActivityList = () => {
    return (
      <div>
        <div className="activity_title flex justify-between">
          <p>Recent Activities</p>
          <button type="button" className="bg-gray-200 px-4">
            Clear All
          </button>
        </div>
  
      
        <ActivityItem
          icon={cross}
          taskName="test task 2022"
          taskStatus="Created"
          timeAgo="1 week ago"
        />
        <ActivityItem
          icon={trash}
          taskName="test task 2022"
          taskStatus="Removed"
          timeAgo="1 week ago"
        />
        <ActivityItem
          icon={cross}
          taskName="task proton1"
          taskStatus="Created"
          timeAgo="1 week ago"
        />
      </div>
    );
  };
  export default ActivityList;