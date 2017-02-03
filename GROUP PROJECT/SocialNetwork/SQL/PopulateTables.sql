 -- DELETE ALL TABLES (FOR THE LOVE OF GOD DONT RUN THESE)
 -- DROP TABLE __MigrationHistory;
 -- DROP TABLE Comments;
 -- DROP TABLE Posts;
 -- DROP TABLE Users;
 -- DROP TABLE Groups;
 -- DROP TABLE UserFriends
 -- DROP TABLE UserGroups
 
 
 --	DELETE ENTRIES FROM DATABASE (Not Tables)
DELETE FROM Comments
DELETE FROM Posts
DELETE FROM Groups
DELETE FROM Users
DELETE FROM UserFriends
DELETE FROM UserGroups

 -- RESEED PRIMARY KEY VALUES (START FROM 0 AGAIN)
DBCC CHECKIDENT (Users, RESEED, 0)
DBCC CHECKIDENT (Comments, RESEED, 0)
DBCC CHECKIDENT (Posts, RESEED, 0)
DBCC CHECKIDENT (Groups, RESEED, 0)


 -- Populate Users
INSERT INTO Users(username, password, fullName, gender, role)
VALUES ('snewton', 'password', 'Spencer Newton', 'Male', 'Admin');
INSERT INTO Users(username, password, fullName, gender, role)
VALUES ('bmeghani', 'password', 'Bishan Meghani', 'Male', 'Admin');
INSERT INTO Users(username, password, fullName, gender, role)
VALUES ('skhan', 'password', 'Suleman Khan', 'Male', 'Admin');
INSERT INTO Users(username, password, fullName, gender, role)
VALUES ('anorman', 'password', 'Andrew Norman', 'Male', 'Admin');
INSERT INTO Users(username, password, fullName, gender, role)
VALUES ('mreid', 'password', 'Mario Reid', 'Male', 'Admin');
INSERT INTO Users(username, password, fullName, gender, role)
VALUES ('dmason', 'password', 'Daniel Mason', 'Male', 'Admin');
INSERT INTO Users(username, password, fullName, gender, role)
VALUES ('bbowes', 'password', 'Benjamin Bowes', 'Male', 'Admin');
INSERT INTO Users(username, password, fullName, gender, role)
VALUES ('ebowes', 'password', 'Erika Bowes', 'Female', 'User');
INSERT INTO Users(username, password, fullName, gender, role)
VALUES ('dtrump', 'maga', 'Donald Trump', 'Male', 'User');

SELECT userId, username, fullName, gender, role FROM Users

 -- Populate User-Friends
INSERT INTO UserFriends(UserRefId, FriendRefId) VALUES (1, 2);
INSERT INTO UserFriends(UserRefId, FriendRefId) VALUES (1, 3);
INSERT INTO UserFriends(UserRefId, FriendRefId) VALUES (1, 4);
INSERT INTO UserFriends(UserRefId, FriendRefId) VALUES (1, 5);
INSERT INTO UserFriends(UserRefId, FriendRefId) VALUES (1, 6);
INSERT INTO UserFriends(UserRefId, FriendRefId) VALUES (1, 7);
INSERT INTO UserFriends(UserRefId, FriendRefId) VALUES (1, 8);

INSERT INTO UserFriends(UserRefId, FriendRefId) VALUES (2, 1);
INSERT INTO UserFriends(UserRefId, FriendRefId) VALUES (2, 3);
INSERT INTO UserFriends(UserRefId, FriendRefId) VALUES (2, 4);
INSERT INTO UserFriends(UserRefId, FriendRefId) VALUES (2, 5);
INSERT INTO UserFriends(UserRefId, FriendRefId) VALUES (2, 6);
INSERT INTO UserFriends(UserRefId, FriendRefId) VALUES (2, 7);
INSERT INTO UserFriends(UserRefId, FriendRefId) VALUES (2, 8);

INSERT INTO UserFriends(UserRefId, FriendRefId) VALUES (3, 1);
INSERT INTO UserFriends(UserRefId, FriendRefId) VALUES (3, 2);
INSERT INTO UserFriends(UserRefId, FriendRefId) VALUES (3, 4);
INSERT INTO UserFriends(UserRefId, FriendRefId) VALUES (3, 5);
INSERT INTO UserFriends(UserRefId, FriendRefId) VALUES (3, 6);
INSERT INTO UserFriends(UserRefId, FriendRefId) VALUES (3, 7);
INSERT INTO UserFriends(UserRefId, FriendRefId) VALUES (3, 8);

INSERT INTO UserFriends(UserRefId, FriendRefId) VALUES (4, 1);
INSERT INTO UserFriends(UserRefId, FriendRefId) VALUES (4, 2);
INSERT INTO UserFriends(UserRefId, FriendRefId) VALUES (4, 3);
INSERT INTO UserFriends(UserRefId, FriendRefId) VALUES (4, 5);
INSERT INTO UserFriends(UserRefId, FriendRefId) VALUES (4, 6);
INSERT INTO UserFriends(UserRefId, FriendRefId) VALUES (4, 7);
INSERT INTO UserFriends(UserRefId, FriendRefId) VALUES (4, 8);

INSERT INTO UserFriends(UserRefId, FriendRefId) VALUES (5, 1);
INSERT INTO UserFriends(UserRefId, FriendRefId) VALUES (5, 2);
INSERT INTO UserFriends(UserRefId, FriendRefId) VALUES (5, 3);
INSERT INTO UserFriends(UserRefId, FriendRefId) VALUES (5, 4);
INSERT INTO UserFriends(UserRefId, FriendRefId) VALUES (5, 6);
INSERT INTO UserFriends(UserRefId, FriendRefId) VALUES (5, 7);
INSERT INTO UserFriends(UserRefId, FriendRefId) VALUES (5, 8);

INSERT INTO UserFriends(UserRefId, FriendRefId) VALUES (6, 1);
INSERT INTO UserFriends(UserRefId, FriendRefId) VALUES (6, 2);
INSERT INTO UserFriends(UserRefId, FriendRefId) VALUES (6, 3);
INSERT INTO UserFriends(UserRefId, FriendRefId) VALUES (6, 4);
INSERT INTO UserFriends(UserRefId, FriendRefId) VALUES (6, 5);
INSERT INTO UserFriends(UserRefId, FriendRefId) VALUES (6, 7);
INSERT INTO UserFriends(UserRefId, FriendRefId) VALUES (6, 8);

INSERT INTO UserFriends(UserRefId, FriendRefId) VALUES (7, 1);
INSERT INTO UserFriends(UserRefId, FriendRefId) VALUES (7, 2);
INSERT INTO UserFriends(UserRefId, FriendRefId) VALUES (7, 3);
INSERT INTO UserFriends(UserRefId, FriendRefId) VALUES (7, 4);
INSERT INTO UserFriends(UserRefId, FriendRefId) VALUES (7, 5);
INSERT INTO UserFriends(UserRefId, FriendRefId) VALUES (7, 6);
INSERT INTO UserFriends(UserRefId, FriendRefId) VALUES (7, 8);

INSERT INTO UserFriends(UserRefId, FriendRefId) VALUES (8, 1);
INSERT INTO UserFriends(UserRefId, FriendRefId) VALUES (8, 2);
INSERT INTO UserFriends(UserRefId, FriendRefId) VALUES (8, 3);
INSERT INTO UserFriends(UserRefId, FriendRefId) VALUES (8, 4);
INSERT INTO UserFriends(UserRefId, FriendRefId) VALUES (8, 5);
INSERT INTO UserFriends(UserRefId, FriendRefId) VALUES (8, 6);

SELECT U1.username, U2.username FROM UserFriends
INNER JOIN Users U1 ON U1.userId = UserRefId
INNER JOIN Users U2 ON U2.userId = FriendRefId;

 -- Populate Groups
INSERT INTO Groups(groupName, owner_userId) VALUES ('Cerf Squad', 1);
INSERT INTO Groups(groupName, owner_userId) VALUES ('USA Presidents', 9);

SELECT groupID, groupName, username FROM Groups
INNER JOIN Users ON Groups.owner_userId = Users.userId;

 -- Populate User-Groups
INSERT INTO UserGroups(GroupRefId, UserRefId) VALUES (1, 1);
INSERT INTO UserGroups(GroupRefId, UserRefId) VALUES (1, 2);
INSERT INTO UserGroups(GroupRefId, UserRefId) VALUES (1, 3);
INSERT INTO UserGroups(GroupRefId, UserRefId) VALUES (1, 4);
INSERT INTO UserGroups(GroupRefId, UserRefId) VALUES (1, 5);
INSERT INTO UserGroups(GroupRefId, UserRefId) VALUES (1, 6);
INSERT INTO UserGroups(GroupRefId, UserRefId) VALUES (1, 7);
INSERT INTO UserGroups(GroupRefId, UserRefId) VALUES (2, 9);

SELECT G.groupName, U.username FROM UserGroups
INNER JOIN Users U ON U.userId = UserRefId
INNER JOIN Groups G ON G.groupId = GroupRefId;

 -- Populate Posts
INSERT INTO Posts(time, likes, title, content, code, language, user_userId, Discriminator) 
VALUES (GETDATE(), 10, 'I Love C#', 'Hi Guys, here is my latest snippet of c# code!', 'Console.WriteLine("I LOVE C#!");', 'C#', 2, 'UserPost');

INSERT INTO Posts(time, likes, title, content, code, language, user_userId, Discriminator)
VALUES(GETDATE(), 15, 'Generic Repository', 'I have made a generic repository for you guys to share - Spencer', 
'public class Repository<T> : IRepository<T> \n{\n\tCODE\n}', 'C#', 1, 'UserPost');

INSERT INTO Posts(time, likes, title, content, code, language, user_userId, Discriminator)
VALUES(GETDATE(), 97, 'MS Test', 'I have written some tests here, what do you guys think?', 
'[TestMethod]\npublic void Test_Method_WhatIExpect_WhenIDoThis()\n{\n\n}', 'C#', 5, 'UserPost');

INSERT INTO Posts(time, likes, title, content, code, language, user_userId, Discriminator)
VALUES(GETDATE(), 167, 'ASP.Net Website', 'Here is my Snazzy Website', 
'<h4>My Snazzy Website</h4>', 'HTML', 6, 'UserPost');

INSERT INTO Posts(time, likes, title, content, code, language, user_userId, Discriminator)
VALUES(GETDATE(), 13, 'WPF Program', 'Im pretty proud of this WPF application I made for my group project :)', 
'<Label Content="I am the best" />', 'XML', 7, 'UserPost');

INSERT INTO Posts(time, likes, title, content, code, language, group_groupId, Discriminator) 
VALUES (GETDATE(), 20, 'I Despise C#', 'I Hate C# so much, here is some terrible code to tell you about it.', 
'Console.WriteLine("I HATE C#!!!");', 'C#', 1, 'GroupPost');

SELECT postId, time, likes, title, language, content, code, Discriminator, group_groupID, user_userId FROM Posts;

 -- Populate Comments
INSERT INTO Comments(content, post_postId, user_userId, likes) VALUES ('This pretty good! Mind if I use it? - Bish', 2, 2, 1);
INSERT INTO Comments(content, post_postId, user_userId, likes) VALUES ('This was copied from me! Take this down!', 2, 4, 55);
INSERT INTO Comments(content, post_postId, user_userId, likes) VALUES ('Nice Testing! Daniel would be proud :)', 3, 3, 78);
INSERT INTO Comments(content, post_postId, user_userId, likes) VALUES ('This website looks sweet! Can I offer you a job as a front end developer?', 4, 9, 0);
INSERT INTO Comments(content, post_postId, user_userId, likes) VALUES ('No...', 4, 6, 999);
INSERT INTO Comments(content, post_postId, user_userId, likes) VALUES ('Looks awesome brother!', 5, 8, 3047889);

SELECT commentId, content, post_postId, user_userId, likes FROM Comments;