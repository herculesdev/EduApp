import Service from "./Service";

class StudentService extends Service {
  constructor() {
    super();
    this.StudentUrl = this.baseUrl + "student/";
  }

  async getAll(name = "") {
    const response = await fetch(this.StudentUrl + `?name=${name}`, {
      method: "GET",
    });

    return this.checkError(response);
  }

  async getById(id) {
    const response = await fetch(this.StudentUrl + id, {
      method: "GET",
    });

    return this.checkError(response);
  }

  async delete(id) {
    const response = await fetch(this.StudentUrl + id, {
      method: "DELETE",
    });

    return this.checkError(response);
  }

  async add(student) {
    const response = await fetch(this.StudentUrl, {
      method: "POST",
      headers: {
        Accept: "application/json, text/plain, */*",
        "Content-Type": "application/json",
      },
      body: JSON.stringify(student),
    });

    return this.checkError(response);
  }

  async update(student) {
    const response = await fetch(this.StudentUrl, {
      method: "PUT",
      headers: {
        Accept: "application/json, text/plain, */*",
        "Content-Type": "application/json",
      },
      body: JSON.stringify(student),
    });

    return this.checkError(response);
  }
}

export default new StudentService();
