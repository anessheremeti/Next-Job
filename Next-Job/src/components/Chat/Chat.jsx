import Nav from "../Navbar/navbar";
import settings from "../../assets/Messages options → Button.png";
import UsersList from "../UsersList/UsersList";
import searchh from "../../assets/searchb.png";
import filter from "../../assets/Vector (3).png";
import send from "../../assets/Vector (4).png";
import { useState } from "react";
import DummyUsers from "../DummyUsers/DummyUsers";
import Footer from "../Footer/footer";
const Chat = () => {
  const [message, setMessage] = useState("");
  const [messages, setMessages] = useState({}); // Changed to an object
  const [search, setSearch] = useState("");
  const [selectedUserId, setSelectedUserId] = useState(null); // ✅ NEW state

  const onChangeHandler = (e) => {
    setMessage(e.target.value);
  };
  const onClickHandler = () => {
    if (message.trim() === "" || !selectedUserId) return;

    setMessages((prev) => ({
      ...prev,
      [selectedUserId]: [...(prev[selectedUserId] || []), message],
    }));
    setMessage("");
  };

  let date = new Date();

  let n = date.toLocaleString([], {
    hour: "2-digit",
    minute: "2-digit",
  });
  const filteredUsers = DummyUsers.filter((item) =>
    item.name.toLowerCase().includes(search.toLowerCase())
  );

  return (
    <div>
      <Nav />
      <div>
        <p className="text-center items-center">
          Development & IT | AI Services | Design & Creative | Sales & Marketing
          | Admin & Customer Support
        </p>
        <div className="main_content m-auto px-24 py-10 flex flex-wrap">
          <div className="left_container px-16 ">
            <div className="text_and_icon flex gap-20 pt-10 justify-around">
              <p className="pt-1 pr-10">Messages</p>
              <img className="w-5 h-5" src={settings} />
            </div>
            <div className="input_and_image text_and_icon flex gap-5 pt-10 justify-around ">
              <li className="list-none">
                <img className="w-7 absolute pt-2 pl-2 " src={searchh} />
                <input
                  className="rounded-xl p-2 place-items-center placeholder:pl-7 "
                  type="text"
                  placeholder="Search...."
                  value={search}
                  onChange={(e) => setSearch(e.target.value)}
                />
              </li>
              <img className="w-5 h-5" src={filter} />
            </div>
            <div className="content flex-column min-h-[400px] overflow-y-auto">
              <UsersList
                users={filteredUsers}
                selectedUserId={selectedUserId}
                setSelectedUserId={setSelectedUserId}
              />
            </div>
          </div>

          <div className="right_container px-10 py-10 flex flex-col flex-1 h-[80vh]">
            <div className="title px-2 flex items-center gap-4">
              {selectedUserId ? (
                <>
                  <img
                    src={
                      DummyUsers.find((u) => u.id === selectedUserId)?.imgUrl
                    }
                    alt="User Avatar"
                    className="w-10 h-10 rounded-full"
                  />
                  <p className="text-gray-800 font-medium">
                    {DummyUsers.find((u) => u.id === selectedUserId)?.name}
                  </p>
                </>
              ) : (
                <p className="text-gray-500">Select a user to start chatting</p>
              )}

              {selectedUserId && <p className="text-gray-400 px-3">{n}</p>}
            </div>

            <div className="messages overflow-y-auto flex-1 py-5 px-1 space-y-4">
              {(messages[selectedUserId] || []).map((msg, index) => (
                <div key={index} className="flex items-center">
                  <img
                    src={
                      DummyUsers.find((u) => u.id === selectedUserId)?.imgUrl
                    }
                    className="w-10 h-10 rounded-full"
                    alt="User"
                  />
                  <div className="p-5 rounded-md text-gray-800 px-5 bg-gray-100 ml-2">
                    <p>{msg}</p>
                  </div>
                </div>
              ))}
            </div>

            {selectedUserId && (
              <div className="send_message shadow-sm bg-white p-2 rounded-md flex">
                <input
                  type="text"
                  placeholder="Send message"
                  className="p-5 bg-gray text-gray-900 border border-gray-300 rounded-md w-full outline-none"
                  onChange={onChangeHandler}
                  value={message}
                />
                <img
                  onClick={onClickHandler}
                  className=" absolute right-36 hover:cursor-pointer w-6 h-6 self-center mr-5"
                  src={send}
                  alt=""
                />
              </div>
            )}
          </div>
        </div>
        <Footer />
      </div>
    </div>
  );
};

export default Chat;
