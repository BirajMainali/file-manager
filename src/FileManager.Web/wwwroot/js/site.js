const Http = {
  Post: async (url, data = {}, options = {
    "Content-Type": "application/json"
  }) => {
    return await fetch(url, {
      method: "POST",
      headers: options,
      body: JSON.stringify(data)
    }).then(res => res.json().then(r => {
      if (res.ok) return r;
      throw r;
    }))
  },


  Get: async (url) => {
    return fetch(url).then(res => res.json()).data;
  },

  Error: async (err, defaultMessage = "An error occured during request") => {
    let message = null;
    if (typeof err === "string") {
      message = err;
    } else {
      message = defaultMessage
    }
    alert(message);
  }

}
