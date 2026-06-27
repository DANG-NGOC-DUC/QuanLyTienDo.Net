PRAGMA foreign_keys = ON;

-- =========================
-- USERS
-- =========================
CREATE TABLE IF NOT EXISTS Users (
    UserId INTEGER PRIMARY KEY AUTOINCREMENT,
    Username TEXT NOT NULL UNIQUE,
    PasswordHash TEXT NOT NULL,
    FullName TEXT NOT NULL,
    Email TEXT,
    Role TEXT NOT NULL,
    ProjectId INTEGER,
    IsActive INTEGER NOT NULL DEFAULT 1,
    CreatedAt TEXT NOT NULL,
    FOREIGN KEY(ProjectId) REFERENCES Projects(ProjectId)
);

-- =========================
-- PROJECTS
-- =========================
CREATE TABLE IF NOT EXISTS Projects (
    ProjectId INTEGER PRIMARY KEY AUTOINCREMENT,
    ProjectName TEXT NOT NULL,
    Description TEXT,
    StartDate TEXT,
    EndDate TEXT,
    Status TEXT,
    ManagerId INTEGER NOT NULL,
    CreatedAt TEXT NOT NULL,
    FOREIGN KEY(ManagerId) REFERENCES Users(UserId)
);

-- =========================
-- TASKS
-- =========================
CREATE TABLE IF NOT EXISTS Tasks (
    TaskId INTEGER PRIMARY KEY AUTOINCREMENT,
    ProjectId INTEGER NOT NULL,
    AssignedTo INTEGER NOT NULL,
    TaskName TEXT NOT NULL,
    Description TEXT,
    StartDate TEXT,
    DueDate TEXT,
    CurrentProgress INTEGER NOT NULL DEFAULT 0,
    Status TEXT,
    Priority TEXT,
    CreatedAt TEXT NOT NULL,
    FOREIGN KEY(ProjectId) REFERENCES Projects(ProjectId),
    FOREIGN KEY(AssignedTo) REFERENCES Users(UserId)
);

-- =========================
-- TASKCOMMENTS
-- =========================
CREATE TABLE IF NOT EXISTS TaskComments (
    CommentId INTEGER PRIMARY KEY AUTOINCREMENT,
    TaskId INTEGER NOT NULL,
    UserId INTEGER NOT NULL,
    Content TEXT NOT NULL,
    CreatedAt TEXT NOT NULL,
    FOREIGN KEY(TaskId) REFERENCES Tasks(TaskId),
    FOREIGN KEY(UserId) REFERENCES Users(UserId)
);
