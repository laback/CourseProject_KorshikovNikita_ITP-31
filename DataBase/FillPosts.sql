use Course1
go

create procedure FillPosts as

declare @count int, @nameOfPost varchar(15)
set @count = 501
while @count > 0
	begin
		set @nameOfPost = char(rand()*26+65)+char(rand()*26+65)+char(rand()*26+65)
						 +char(rand()*26+65)+char(rand()*26+65)+char(rand()*26+65)
						 +char(rand()*26+65)+char(rand()*26+65)+char(rand()*26+65)
						 +char(rand()*26+65)+char(rand()*26+65)+char(rand()*26+65)
						 +char(rand()*26+65)+char(rand()*26+65)+char(rand()*26+65)
		insert into Posts values(@nameOfPost)
		set @count = @count - 1
	end