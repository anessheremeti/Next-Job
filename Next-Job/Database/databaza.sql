CREATE DATABASE FreelancerManagement;
GO
USE FreelancerManagement;
GO

-- Users Table
CREATE TABLE Users (
    id INT IDENTITY(1,1) PRIMARY KEY,
    user_type VARCHAR(20) CHECK (user_type IN ('client', 'company', 'freelancer')) NOT NULL,
    full_name NVARCHAR(255),
    company_name NVARCHAR(255),
    email NVARCHAR(255) UNIQUE NOT NULL,
    password_hash NVARCHAR(255) NOT NULL,
    created_at DATETIME DEFAULT GETDATE(),
    CHECK ((user_type IN ('client', 'freelancer') AND full_name IS NOT NULL) OR 
           (user_type = 'company' AND company_name IS NOT NULL))
);

-- Client Profile
CREATE TABLE ClientProfile (
    id INT IDENTITY(1,1) PRIMARY KEY,
    user_id INT UNIQUE,
    image NVARCHAR(255),
    skills TEXT,
    job_success DECIMAL(5,2),
    total_jobs INT,
    total_hours INT,
    in_queue_service INT,
    location NVARCHAR(255),
    last_delivery DATE,
    member_since DATE,
    education TEXT,
    gender VARCHAR(20) CHECK (gender IN ('male', 'female', 'other')),
    english_level VARCHAR(20) CHECK (english_level IN ('beginner', 'intermediate', 'advanced', 'fluent')) NOT NULL,
    FOREIGN KEY (user_id) REFERENCES Users(id) ON DELETE CASCADE ON UPDATE CASCADE
);

-- Freelancer Profile
CREATE TABLE FreelancerProfile (
    id INT IDENTITY(1,1) PRIMARY KEY,
    user_id INT UNIQUE,
    skills TEXT,
    hourly_rate DECIMAL(10,2),
    portfolio_link NVARCHAR(255),
    location NVARCHAR(255),
    last_delivery DATE,
    member_since DATE,
    FOREIGN KEY (user_id) REFERENCES Users(id) ON DELETE CASCADE ON UPDATE CASCADE
);

-- Company Table
CREATE TABLE Company (
    id INT IDENTITY(1,1) PRIMARY KEY,
    owner_id INT NOT NULL,
    name NVARCHAR(255) NOT NULL,
    description TEXT,
    website NVARCHAR(255),
    created_at DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (owner_id) REFERENCES Users(id) ON DELETE SET NULL ON UPDATE CASCADE
);

-- Job Info
CREATE TABLE JobInfo (
    id INT IDENTITY(1,1) PRIMARY KEY,
    job_title NVARCHAR(255) NOT NULL,
    vacancies INT NOT NULL,
    job_types VARCHAR(20) CHECK (job_types IN ('fulltime', 'parttime', 'contract')) NOT NULL,
    job_tag NVARCHAR(255),
    job_category NVARCHAR(255),
    budget_type VARCHAR(20) CHECK (budget_type IN ('fixed', 'range', 'negotiable')) NOT NULL,
    budget DECIMAL(10,2),
    experience_level VARCHAR(20) CHECK (experience_level IN ('entry', 'mid', 'senior')) NOT NULL,
    deadline DATE NOT NULL,
    job_description TEXT NOT NULL
);

-- Applications Table
CREATE TABLE Applications (
    id INT IDENTITY(1,1) PRIMARY KEY,
    job_id INT,
    freelancer_id INT,
    cover_letter TEXT NOT NULL,
    date_applied DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (job_id) REFERENCES JobInfo(id) ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY (freelancer_id) REFERENCES Users(id) ON DELETE CASCADE ON UPDATE CASCADE
);

-- Contracts Table
CREATE TABLE Contracts (
    id INT IDENTITY(1,1) PRIMARY KEY,
    freelancer_id INT NOT NULL,
    client_id INT NOT NULL,
    job_id INT NOT NULL,
    start_date DATETIME DEFAULT GETDATE(),
    end_date DATETIME,
    status VARCHAR(50) CHECK (status IN ('Active', 'Completed', 'Cancelled')),
    FOREIGN KEY (freelancer_id) REFERENCES Users(id) ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY (client_id) REFERENCES Users(id) ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY (job_id) REFERENCES JobInfo(id) ON DELETE CASCADE ON UPDATE CASCADE
);

-- Payments Table
CREATE TABLE Payments (
    id INT IDENTITY(1,1) PRIMARY KEY,
    contract_id INT NOT NULL,
    amount DECIMAL(10,2) NOT NULL,
    payment_date DATETIME DEFAULT GETDATE(),
    status VARCHAR(50) CHECK (status IN ('Pending', 'Completed', 'Failed')),
    FOREIGN KEY (contract_id) REFERENCES Contracts(id) ON DELETE CASCADE ON UPDATE CASCADE
);

-- Reviews Table
CREATE TABLE Reviews (
    id INT IDENTITY(1,1) PRIMARY KEY,
    reviewer_id INT NOT NULL,
    reviewed_user_id INT NOT NULL,
    rating INT CHECK (rating BETWEEN 1 AND 5),
    comment TEXT,
    created_at DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (reviewer_id) REFERENCES Users(id) ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY (reviewed_user_id) REFERENCES Users(id) ON DELETE CASCADE ON UPDATE CASCADE
);

-- Messages Table
CREATE TABLE Messages (
    id INT IDENTITY(1,1) PRIMARY KEY,
    sender_id INT,
    receiver_id INT,
    message TEXT NOT NULL,
    date_time DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (sender_id) REFERENCES Users(id) ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY (receiver_id) REFERENCES Users(id) ON DELETE CASCADE ON UPDATE CASCADE
);

-- Notifications Table
CREATE TABLE Notifications (
    id INT IDENTITY(1,1) PRIMARY KEY,
    user_id INT NOT NULL,
    message TEXT NOT NULL,
    is_read BIT DEFAULT 0,
    created_at DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (user_id) REFERENCES Users(id) ON DELETE CASCADE ON UPDATE CASCADE
);

-- History Table
CREATE TABLE History (
    id INT IDENTITY(1,1) PRIMARY KEY,
    user_id INT NOT NULL,
    action TEXT NOT NULL,
    timestamp DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (user_id) REFERENCES Users(id) ON DELETE CASCADE ON UPDATE CASCADE
);
