CREATE VIEW CourseInformation AS
SELECT C.Code, C.Name AS Title, S.Name AS Semester, T.Name AS Teacher 
FROM Course AS C
LEFT JOIN Semester AS S ON C.SemesterId = S.SemesterId
LEFT JOIN CourseAssignToTeacher AS Co ON C.CourseId = Co.CourseId
LEFT JOIN Teacher AS T ON Co.TeacherId = T.TeacherId
