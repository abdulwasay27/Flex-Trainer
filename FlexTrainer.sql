CREATE DATABASE FlexTrainer;

USE FlexTrainer;

-- Define Admin table
CREATE TABLE Admin (
    adminEmail VARCHAR(100) PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    password VARCHAR(100) NOT NULL
);

-- Define GymOwner table
CREATE TABLE GymOwner (
    ownerEmail VARCHAR(100) PRIMARY KEY,
    addedBy VARCHAR(100) FOREIGN KEY REFERENCES Admin(AdminEmail),
    name VARCHAR(100) NOT NULL,
    password VARCHAR(100) NOT NULL
);

-- Define Trainer table
CREATE TABLE Trainer (
    trainerEmail VARCHAR(100) PRIMARY KEY,
    addedBy VARCHAR(100) FOREIGN KEY REFERENCES GymOwner(ownerEmail),
    name VARCHAR(100) NOT NULL,
    password VARCHAR(100) NOT NULL,
    speciality VARCHAR(100),
    experience INT,
    qualification VARCHAR(200),
    isVerified bit
);

-- Define Meal table
CREATE TABLE Meal (
    mealName VARCHAR(100) PRIMARY KEY,
    allergen VARCHAR(100),
    fibre DECIMAL(5,2),
    fats DECIMAL(5,2),
    carbs DECIMAL(5,2),
    protein DECIMAL(5,2),
    calories INT,
    nutrition AS (fibre + carbs + protein + fats) PERSISTED,
    portionSize VARCHAR(100)
);

-- Define Exercise table
CREATE TABLE Exercise (
    exerciseName VARCHAR(100) PRIMARY KEY,
    targetMuscle VARCHAR(100)
);

-- Define WorkoutPlan table
CREATE TABLE WorkoutPlan (
    workoutPlanID INT PRIMARY KEY,
    trainerEmail VARCHAR(100),
    memberEmail VARCHAR(100),
    goal VARCHAR(200),
    schedule VARCHAR(200),
    experienceLevel VARCHAR(100),
);

-- Define Workout_Exercises table
CREATE TABLE Workout_Exercises (
    day VARCHAR(20),
    workoutPlanID INT,
    exerciseName VARCHAR(100),
    sets INT,
    reps INT,
    PRIMARY KEY (day, workoutPlanID, exerciseName),
    FOREIGN KEY (workoutPlanID) REFERENCES WorkoutPlan(workoutPlanID)
);

-- Define DietPlan table
CREATE TABLE DietPlan (
    dietPlanID INT PRIMARY KEY,
    trainerEmail VARCHAR(100),
    memberEmail VARCHAR(100),
    purpose VARCHAR(200),
    typeOfDiet VARCHAR(100),  
);

-- Define Diet_Meal table
CREATE TABLE Diet_Meal (
    day VARCHAR(20),
    dietPlanID INT,
    mealName VARCHAR(100),
    PRIMARY KEY (day, dietPlanID, mealName),
    FOREIGN KEY (dietPlanID) REFERENCES DietPlan(dietPlanID)
);

-- Define Gym table
CREATE TABLE Gym (
    gymName VARCHAR(100) PRIMARY KEY,
    gymOwner VARCHAR(100),
    adminEmail VARCHAR(100),
    isApproved BIT,
    location VARCHAR(100),
	membership_fees INT,
    customerSatisfaction INT,
    classAttendanceRate DECIMAL(5,2),
    membershipGrowth INT,
    financialPerformance DECIMAL(10,2),
    FOREIGN KEY (gymOwner) REFERENCES GymOwner(ownerEmail),
    FOREIGN KEY (adminEmail) REFERENCES Admin(adminEmail)
);
CREATE TABLE Gym_CustomerSatisfaction (
	gymName VARCHAR(100) PRIMARY KEY,
	memberEmail VARCHAR(100),
	customerSatisfaction INT
);
CREATE TABLE Gym_classAttendance (
	gymName VARCHAR(100) PRIMARY KEY,
	memberEmail VARCHAR(100),
	date DATE,
	isPresent BIT
);
CREATE TABLE Gym_Membership (
	gymName VARCHAR(100) PRIMARY KEY,
	memberEmail VARCHAR(100),
	date DATE
);

-- Define Member table
CREATE TABLE Member (
    memberEmail VARCHAR(100) PRIMARY KEY,
    addedBy VARCHAR(100),
    trainerEmail VARCHAR(100),
    dietPlanID INT,
    workoutPlanID INT,
    gymName VARCHAR(100),
    memberName VARCHAR(100) NOT NULL,
    password VARCHAR(100) NOT NULL,
    membershipDuration INT,
    objectives VARCHAR(200),
	signup_date DATE,
    FOREIGN KEY (addedBy) REFERENCES GymOwner(ownerEmail),
    FOREIGN KEY (trainerEmail) REFERENCES Trainer(trainerEmail),
    FOREIGN KEY (dietPlanID) REFERENCES DietPlan(dietPlanID),
    FOREIGN KEY (workoutPlanID) REFERENCES WorkoutPlan(workoutPlanID),
    FOREIGN KEY (gymName) REFERENCES Gym(gymName)
);

-- Define TrainerRating table
CREATE TABLE TrainerRating (
    trainerEmail VARCHAR(100),
	memberEmail VARCHAR(100),
    rating INT,
    PRIMARY KEY (trainerEmail, memberEmail),
	FOREIGN KEY (memberEmail) REFERENCES Member(memberEmail),
    FOREIGN KEY (trainerEmail) REFERENCES Trainer(trainerEmail)
);

-- Define GymTrainers table
CREATE TABLE GymTrainers (
    gymName VARCHAR(100),
    trainerEmail VARCHAR(100),
    PRIMARY KEY (gymName, trainerEmail),
    FOREIGN KEY (gymName) REFERENCES Gym(gymName),
    FOREIGN KEY (trainerEmail) REFERENCES Trainer(trainerEmail)
);

-- Define Gym_Machines table
CREATE TABLE Gym_Machines (
    gymName VARCHAR(100),
    exerciseName VARCHAR(100),
    machineName VARCHAR(100),
    PRIMARY KEY (gymName, exerciseName, machineName),
    FOREIGN KEY (gymName) REFERENCES Gym(gymName),
	FOREIGN KEY (exerciseName) REFERENCES Exercise(exerciseName)
);

-- Define Verification table
CREATE TABLE Verification (
    trainerEmail VARCHAR(100),
    gymOwner VARCHAR(100),
    PRIMARY KEY (trainerEmail, gymOwner),
    FOREIGN KEY (trainerEmail) REFERENCES Trainer(trainerEmail),
    FOREIGN KEY (gymOwner) REFERENCES GymOwner(ownerEmail)
);

-- Define TrainerReport table
CREATE TABLE TrainerReport (
    reportID INT PRIMARY KEY,
    trainerEmail VARCHAR(100),
    gymOwnerEmail VARCHAR(100),
    FOREIGN KEY (trainerEmail) REFERENCES Trainer(trainerEmail),
    FOREIGN KEY (gymOwnerEmail) REFERENCES GymOwner(ownerEmail)
);

-- Define MemberReport table
CREATE TABLE MemberReport (
    reportID INT PRIMARY KEY,
    memberEmail VARCHAR(100),
    gymOwnerEmail VARCHAR(100),
    FOREIGN KEY (memberEmail) REFERENCES Member(memberEmail),
    FOREIGN KEY (gymOwnerEmail) REFERENCES GymOwner(ownerEmail)
);

-- Define Appointment table
CREATE TABLE Appointment (
    trainerEmail VARCHAR(100),
    memberEmail VARCHAR(100),
    isAppointmentActive BIT,
    appointmentDescription VARCHAR(200),
    date DATE,
    FOREIGN KEY (trainerEmail) REFERENCES Trainer(trainerEmail),
    FOREIGN KEY (memberEmail) REFERENCES Member(memberEmail)
);

-- Define Feedback table
CREATE TABLE Feedback (
    trainerEmail VARCHAR(100),
    memberEmail VARCHAR(100),
    feedbackContent TEXT,
    FOREIGN KEY (trainerEmail) REFERENCES Trainer(trainerEmail),
    FOREIGN KEY (memberEmail) REFERENCES Member(memberEmail)
);

-- Define Approval table
CREATE TABLE Approval (
    approvalID INT PRIMARY KEY,
    gymOwnerEmail VARCHAR(100),
    adminEmail VARCHAR(100),
    gymName VARCHAR(100),
    location VARCHAR(100),
    facilitySpecification TEXT,
    activeMembers INT,
    businessPlan VARCHAR(100),
    FOREIGN KEY (gymOwnerEmail) REFERENCES GymOwner(ownerEmail),
    FOREIGN KEY (adminEmail) REFERENCES Admin(adminEmail),
    FOREIGN KEY (gymName) REFERENCES Gym(gymName)
);

-- Define GymReport table
CREATE TABLE GymReport (
    reportID INT PRIMARY KEY,
    gymName VARCHAR(100),
    adminEmail VARCHAR(100),
    FOREIGN KEY (gymName) REFERENCES Gym(gymName),
    FOREIGN KEY (adminEmail) REFERENCES Admin(adminEmail)
);