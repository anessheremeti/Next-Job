import ProfileCard from "./ProfileCard";
import Profilphoto from "../../assets/profil-photo.png";
import Card5 from '../../assets/card-5.png';

function YourPage() {
  return (
    <div className=" py-10">
      <ProfileCard
        coverImage={Card5}
        profileImage={Profilphoto}
        name="Focused Studio"
        location="Presheva, Albania"
        title="Video Editing & Web Developing"
        description="Just try to work with me and you’ll see: I can do my work well and on time."
        experience="4+ years in website development, editing, animation, Git, AWS, Azure..."
      />
    </div>
  );
}

export default YourPage;
