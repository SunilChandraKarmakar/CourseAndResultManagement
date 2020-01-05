CREATE VIEW StudentResultView
AS
SELECT C.Code, C.Name AS CourseName, GL.Name AS Grade, SR.RegisterStudentId
FROM Course AS C, EnrollCourse AS EC, StudentResult AS SR, GradeLetter AS GL
WHERE C.CourseId = EC.CourseId
AND EC.CourseId = SR.CourseId
AND SR.GradeLetterId = GL.GradeLetterId
GROUP BY C.Code, C.Name, GL.Name, SR.RegisterStudentId
