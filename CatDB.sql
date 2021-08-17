create table cats(
    Id int IDENTITY PRIMARY KEY,
    Name NVARCHAR(20) NOT NULL
);
create table food(
    Id int IDENTITY PRIMARY KEY,
    Name NVARCHAR(10) NOT NULL
);
create table meals(
    Id int IDENTITY PRIMARY KEY,
    Time DATE NOT NULL,
    CatId int foreign key REFERENCES cats(Id),
    FoodType int foreign key REFERENCES food(Id)
);

insert into cats (Name) values (
    'Auryn'
), ('Rosa'), ('Lucky'), ('Pixar'), ('Stinker');
insert into food (Name) values (
    'Dry'
), ('Wet');

select * from cats;