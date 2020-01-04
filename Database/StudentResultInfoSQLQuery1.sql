CREATE VIEW StudentResultInfo
AS
SELECT C.Code, C.Name AS CourseName, GL.Name AS Grade
FROM Course AS C, StudentResult AS SR, GradeLetter AS GL
WHERE C.CourseId = SR.CourseId AND 
SR.GradeLetterId = GL.GradeLetterId
