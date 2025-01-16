using System.ComponentModel;
using Microsoft.AspNetCore.Authorization.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<Teacher> teachers=[
    new(){Name="Micke"},
    new(){Name="Martin"},
    new(){Name="Lena"},
];

app.Urls.Add("http://localhost:5195");
app.Urls.Add("http://*:5195");

app.MapGet("/", GetMe);
app.MapGet("/orb", GetAlso);
app.MapGet("/micke", GetMicke);
app.MapGet("/maxi", GetMaxi);
app.MapGet("/teachers/{n}", GetTeachers);

app.Run();


List<Teacher> GetTeachers(){
    return teachers;
}

IResult GetTeacher(int n){
    if(n>=0&&n<teachers.Count) return Results.Ok(teachers[n]);
    else return Results.NotFound();
}

static Teacher GetMicke(){
    Teacher micke=new() {Name="Micke"};
    return micke;
}

static string GetMaxi(){
    return "Hej, Axel";
}
static string GetAlso(){
    return "Hi, orb";
}

static string GetMe(){
    return "Hello, World";
}