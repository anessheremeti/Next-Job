import React, { useState } from "react";

export default function UploadMedia() {
  const [file, setFile] = useState(null);

  const handleFileChange = (e) => {
    const selectedFile = e.target.files[0];
    if (selectedFile && isValidType(selectedFile)) {
      setFile(selectedFile);
    }
  };

  const isValidType = (file) => {
    const allowedTypes = ["image/", "video/"];
    return allowedTypes.some((type) => file.type.startsWith(type));
  };

  const handleDrop = (e) => {
    e.preventDefault();
    const droppedFile = e.dataTransfer.files[0];
    if (droppedFile && isValidType(droppedFile)) {
      setFile(droppedFile);
    }
  };

  const handleDragOver = (e) => {
    e.preventDefault();
  };

  return (
    <div
      className="border-2 border-dashed border-green-300 p-10 flex justify-center items-center rounded-lg text-center text-gray-400 w-full h-full"
      onDrop={handleDrop}
      onDragOver={handleDragOver}
      onClick={() => document.getElementById("fileInput").click()}
    >
      <input
        id="fileInput"
        type="file"
        accept="image/*,video/*"
        className="hidden"
        onChange={handleFileChange}
      />

      {!file ? (
        <div>
          <div className="text-2xl mb-2">📷 🎬</div>
          <p>Add Content</p>
        </div>
      ) : file.type.startsWith("image/") ? (
        <img
          src={URL.createObjectURL(file)}
          alt="Uploaded"
          className="max-h-48 object-contain"
        />
      ) : (
        <video
          src={URL.createObjectURL(file)}
          controls
          className="max-h-48 object-contain"
        />
      )}
    </div>
  );
}
