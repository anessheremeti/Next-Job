CREATE DATABASE NextJobDB;
GO
USE NextJobDB;
GO


CREATE TABLE UserType (
    UserTypeID INT IDENTITY(1,1) PRIMARY KEY,
    UserTypeName VARCHAR(20) UNIQUE NOT NULL
);

CREATE TABLE Users (
    id INT IDENTITY(1,1) PRIMARY KEY,
    user_type_id INT NOT NULL,
    full_name NVARCHAR(255) NULL,
    company_name NVARCHAR(255) NULL,
    email NVARCHAR(255) NOT NULL,
    password_hash NVARCHAR(255) NOT NULL,
    created_at DATETIME NULL,
    FOREIGN KEY (user_type_id) REFERENCES UserType(UserTypeID)
);

CREATE TABLE Gender (
    GenderID INT IDENTITY(1,1) PRIMARY KEY,
    GenderName VARCHAR(20) NOT NULL
);

CREATE TABLE EnglishLevel (
    EnglishLevelID INT IDENTITY(1,1) PRIMARY KEY,  
    EnglishLevelName VARCHAR(20) NOT NULL  
);

CREATE TABLE ClientProfile (
    id INT IDENTITY(1,1) PRIMARY KEY,
    user_id INT NULL,
    image NVARCHAR(255) NULL,
    skills TEXT NULL,
    job_success DECIMAL NULL,
    total_jobs INT NULL,
    total_hours INT NULL,
    in_queue_service INT NULL,
    location NVARCHAR(255) NULL,
    last_delivery DATE NULL,
    member_since DATE NULL,
    education TEXT NULL,
    genderID INT NULL,
    englishLevelID INT NULL,
    FOREIGN KEY (user_id) REFERENCES Users(id) ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY (genderID) REFERENCES Gender(GenderID),
    FOREIGN KEY (englishLevelID) REFERENCES EnglishLevel(EnglishLevelID)
);

CREATE TABLE FreelancerProfile (
    id INT IDENTITY(1,1) PRIMARY KEY,
    user_id INT NULL,
    skills TEXT NULL,
    hourly_rate DECIMAL NULL,
    portfolio_link NVARCHAR(255) NULL,
    location NVARCHAR(255) NULL,
    last_delivery DATE NULL,
    member_since DATE NULL,
    FOREIGN KEY (user_id) REFERENCES Users(id) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE Company (
    id INT IDENTITY(1,1) PRIMARY KEY,
    owner_id INT NULL,
    name NVARCHAR(255) NOT NULL,
    description TEXT NULL,
    website NVARCHAR(255) NULL,
    created_at DATETIME NULL,
    FOREIGN KEY (owner_id) REFERENCES Users(id) ON DELETE SET NULL ON UPDATE CASCADE
);


CREATE TABLE JobType (
    JobTypeID INT IDENTITY(1,1) PRIMARY KEY,
    JobTypeName VARCHAR(20) NOT NULL UNIQUE
);

CREATE TABLE BudgetType (
    BudgetTypeID INT IDENTITY(1,1) PRIMARY KEY,
    BudgetTypeName VARCHAR(20) NOT NULL UNIQUE
);
CREATE TABLE ExperienceLevel (
    ExperienceLevelID INT IDENTITY(1,1) PRIMARY KEY,
    ExperienceLevelName VARCHAR(20) NOT NULL UNIQUE
);

CREATE TABLE JobInfo (
    id INT IDENTITY(1,1) PRIMARY KEY,
    job_title NVARCHAR(255) NOT NULL,
    vacancies INT NOT NULL,
    job_type_id INT NOT NULL,
    job_tag NVARCHAR(255) NULL,
    job_category NVARCHAR(255) NULL,
    budget_type_id INT NOT NULL,
    budget DECIMAL NULL,
    experience_level_id INT NOT NULL,
    deadline DATE NOT NULL,
    job_description TEXT NOT NULL,
    FOREIGN KEY (job_type_id) REFERENCES JobType(JobTypeID),
    FOREIGN KEY (budget_type_id) REFERENCES BudgetType(BudgetTypeID),
    FOREIGN KEY (experience_level_id) REFERENCES ExperienceLevel(ExperienceLevelID)
);

CREATE TABLE Applications (
    id INT IDENTITY(1,1) PRIMARY KEY,
    job_id INT NULL,
    freelancer_id INT NULL,
    cover_letter TEXT NOT NULL,
    date_applied DATETIME NULL,
    FOREIGN KEY (job_id) REFERENCES JobInfo(id) ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY (freelancer_id) REFERENCES Users(id) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE ContractStatus (
    ContractStatusID INT IDENTITY(1,1) PRIMARY KEY,
    StatusName VARCHAR(50) UNIQUE NOT NULL
);


CREATE TABLE Contracts (
    id INT IDENTITY(1,1) PRIMARY KEY,
    freelancer_id INT NOT NULL,
    client_id INT NOT NULL,
    job_id INT NOT NULL,
    start_date DATETIME NULL,
    end_date DATETIME NULL,
    contract_status_id INT NOT NULL,
    FOREIGN KEY (freelancer_id) REFERENCES Users(id) ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY (client_id) REFERENCES Users(id),
    FOREIGN KEY (job_id) REFERENCES JobInfo(id) ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY (contract_status_id) REFERENCES ContractStatus(ContractStatusID)
);


CREATE TABLE PaymentStatus (
    PaymentStatusID INT IDENTITY(1,1) PRIMARY KEY,
    StatusName VARCHAR(50) UNIQUE NOT NULL
);

CREATE TABLE Payments (
    id INT IDENTITY(1,1) PRIMARY KEY,
    contract_id INT NOT NULL,
    amount DECIMAL NOT NULL,
    payment_date DATETIME NULL,
    payment_status_id INT NOT NULL,
    FOREIGN KEY (contract_id) REFERENCES Contracts(id) ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY (payment_status_id) REFERENCES PaymentStatus(PaymentStatusID)
);

CREATE TABLE Reviews (
    id INT IDENTITY(1,1) PRIMARY KEY,
    reviewer_id INT NOT NULL,
    reviewed_user_id INT NOT NULL,
    rating INT NULL CHECK (rating BETWEEN 1 AND 5),
    comment TEXT NULL,
    created_at DATETIME NULL,
    FOREIGN KEY (reviewer_id) REFERENCES Users(id) ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY (reviewed_user_id) REFERENCES Users(id)
);


CREATE TABLE Messages (
    id INT IDENTITY(1,1) PRIMARY KEY,
    sender_id INT NULL,
    receiver_id INT NULL,
    message TEXT NOT NULL,
    date_time DATETIME NULL,
    FOREIGN KEY (sender_id) REFERENCES Users(id) ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY (receiver_id) REFERENCES Users(id)
);

CREATE TABLE Notifications (
    id INT IDENTITY(1,1) PRIMARY KEY,
    user_id INT NOT NULL,
    message TEXT NOT NULL,
    is_read BIT NULL,
    created_at DATETIME NULL,
    FOREIGN KEY (user_id) REFERENCES Users(id) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE History (
    id INT IDENTITY(1,1) PRIMARY KEY,
    user_id INT NOT NULL,
    action TEXT NOT NULL,
    timestamp DATETIME NULL,
    FOREIGN KEY (user_id) REFERENCES Users(id) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE PasswordResetTokens (
    Id INT PRIMARY KEY IDENTITY,
    Email NVARCHAR(100) NOT NULL,
    Token NVARCHAR(255) NOT NULL,
    Expiration DATETIME NOT NULL
);





