CREATE VIEW ClassSchidule
AS
SELECT C.Code, C.Name AS CourseName, c.DepartmentId,
STRING_AGG(('Room : ' + CR.Name + ', Week: ' + WK.Name + ', Start Time: ' + CAST(ACR.ClassEndTime AS varchar) + ', End Time: ' + CAST(ACR.ClassEndTime AS varchar)) + '<br />' , '') AS Schidule
FROM Course AS C 
LEFT JOIN AllocateClassRoom AS ACR ON C.CourseId = ACR.CourseId
LEFT JOIN ClassRoom AS CR ON ACR.ClassRoomId = CR.ClassRoomId
LEFT JOIN WEEK AS WK ON ACR.WeekId = WK.WeekId
where c.DepartmentId = 1
GROUP BY C.Code, C.Name, c.DepartmentId
