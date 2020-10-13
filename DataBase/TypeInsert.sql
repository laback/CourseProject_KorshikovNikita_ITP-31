use Course1
go

create procedure TypeInsert
	@nameOfType varchar(30)
	as
	insert into Types values(@nameOfType)