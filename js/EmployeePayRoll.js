//UC1
class EmployeePayRoll 
{
   // getter and setter method 
   get name() { return this._name; } 
   set name(name) { 
   let checkName=RegExp('^[A-Z]{1}[a-z]{2,}$');
       if(checkName.test(name))
       {
            this._name=name;
       }
       else
       {
            throw "InCorrect name";
       }
       
   this._name = name; 
   } 

   get profilePic() { return this._profilePic; } 
   set profilePic(profilePic) {
        this._profilePic=profilePic;
    }

    get gender() { return this._gender; } 
   set gender(gender) {
        this._gender=gender;
    }

   get department() { return this._department; } 
   set department(department) {
       this._department=department;
    }

    get salary() { return this._salary; } 
    set salary(salary) {
       this._salary=salary;
    }

    get note() { return this._note; } 
    set note(note) {
       this._note=note;
    }

    get startDate() { return this._startDate; } 
    set startDate(startDate) {
       this._startDate=startDate;
    }
   
   // method 
   toString() {
    const options={year:'numeric',month:'numeric',day:'numeric'};
    const empDate=this.startDate===undefined?"undefined":this.startDate.toLocaleDateString("en-US",options);
     return "id=" + this.id + ", name=" + this.name + ", profilePic=" + this.profilePic+ ", gender=" + this.gender+ ", salary=" + this.salary+ ", startDate=" + empDate + ",  department=" + this.department+ ", note=" + this.note; 
 } 
}
    

