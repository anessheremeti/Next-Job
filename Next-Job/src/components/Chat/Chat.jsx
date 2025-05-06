import Nav from "../Navbar/navbar";
import settings from "../../assets/Messages options → Button.png";
import UsersList from "../UsersList/UsersList";
import searchh from "../../assets/searchb.png";
import filter from "../../assets/Vector (3).png";
import send from "../../assets/Vector (4).png";
import { useEffect, useRef, useState } from "react";
import DummyUsers from "../DummyUsers/DummyUsers";
import Footer from "../Footer/footer";

const Chat = () => {
  const [message, setMessage] = useState("");
  const [messages, setMessages] = useState({});
  const [search, setSearch] = useState("");
  const [selectedUserId, setSelectedUserId] = useState(null);
  const [ws, setWs] = useState(null);

  const scrollRef = useRef(null);
  const curUser = { name: "You" }; 

  useEffect(() => {
    if (selectedUserId) {
      const socket = new WebSocket(`ws://localhost:5123/ws?name=${curUser.name}`);

      socket.onopen = () => {
        console.log("WebSocket connection established");
      };
      socket.onmessage = (event) => {
        const data = event.data;
        if (!data) return;
      
        
        if (data.startsWith(curUser.name + ":")) return;
      
        setMessages((prev) => ({
          ...prev,
          [selectedUserId]: [...(prev[selectedUserId] || []), data],
        }));
      };
      

      socket.onclose = () => {
        console.log("WebSocket connection closed");
      };

      setWs(socket);

      return () => {
        socket.close();
      };
    }
  }, [selectedUserId]);

  const onChangeHandler = (e) => {
    setMessage(e.target.value);
  };

  const onClickHandler = async () => {
    if (message.trim() === "" || !selectedUserId || !ws) return;
  
    const payload = `${curUser.name}: ${message}`;
    ws.send(payload);
  
    setMessages((prev) => ({
      ...prev,
      [selectedUserId]: [...(prev[selectedUserId] || []), payload],
    }));
  
    try {
      await fetch("http://localhost:5123/api/messages", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({
          sender: curUser.name,
          receiverId: selectedUserId,
          content: message,
          timestamp: new Date().toISOString(),
        }),
      });
    } catch (err) {
      console.error("Error saving message:", err);
    }
  
    setMessage("");
  };
  

  useEffect(() => {
    scrollRef.current?.scrollIntoView({ behavior: "smooth" });
  }, [messages[selectedUserId]]);

  const filteredUsers = DummyUsers.filter((item) =>
    item.name.toLowerCase().includes(search.toLowerCase())
  );

  let timeNow = new Date().toLocaleTimeString([], {
    hour: "2-digit",
    minute: "2-digit",
  });

  return (
    <div>
      <Nav />
      <p className="text-center items-center">
        Development & IT | AI Services | Design & Creative | Sales & Marketing |
        Admin & Customer Support
      </p>
      <div className="main_content m-auto px-24 py-10 flex flex-wrap">
        <div className="left_container px-16 ">
          <div className="text_and_icon flex gap-20 pt-10 justify-around">
            <p className="pt-1 pr-10">Messages</p>
            <img className="w-5 h-5" src={settings} />
          </div>
          <div className="input_and_image text_and_icon flex gap-5 pt-10 justify-around ">
            <li className="list-none relative">
              <img className="w-7 absolute pt-2 pl-2" src={searchh} />
              <input
                className="rounded-xl p-2 placeholder:pl-8"
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
            {selectedUserId && (
              <p className="text-gray-400 px-3">{timeNow}</p>
            )}
          </div>

          <div className="messages overflow-y-auto flex-1 py-5 px-1 space-y-4">
            {(messages[selectedUserId] || []).map((msg, index) => (
              <div key={index} className="flex items-center gap-2">
                <img
                  src={
                    DummyUsers.find((u) => u.id === selectedUserId)?.imgUrl
                  }
                  alt="User"
                  className="w-6 h-6 rounded-full"
                />
                <p className="bg-gray-200 px-3 py-1 rounded-xl">{msg}</p>
              </div>
            ))}
            <div ref={scrollRef} />
          </div>

         
          {selectedUserId && (
            <div className="input_area flex gap-4 items-center mt-4">
              <input
                value={message}
                onChange={onChangeHandler}
                onKeyDown={(e) => e.key === "Enter" && onClickHandler()}
                className="flex-1 border border-gray-300 rounded-xl px-4 py-2"
                placeholder="Type your message..."
              />
              <button onClick={onClickHandler}>
                <img src={send} alt="Send" className="w-6 h-6" />
              </button>
            </div>
          )}
        </div>
      </div>
      <Footer />
    </div>
  );
};

export default Chat;
