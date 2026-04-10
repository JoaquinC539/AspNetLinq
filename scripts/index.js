const fsa = require("fs/promises");
const url = "http://localhost:5133";

const postJson = async (jsonObj, endpoint) => {
  try {
    const res = await fetch(`${url}/${endpoint}`, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(jsonObj),
    });

    if (!res.ok) {
      const text = await res.text();
      console.error("HTTP error:", res.status, text);
    }

    return res;
  } catch (e) {
    console.error("Fetch failed:", e);
  }
};
const insertData = async (fileName, endpoint) => {
  try {
    
    const data = await fsa.readFile("./" + fileName, "utf-8");
    const jsonData = JSON.parse(data);
    console.log("Inserting data into "+endpoint+"...")
    await Promise.all(jsonData.map((d) => postJson(d, endpoint)));

    console.log("All requests completed");
  } catch (e) {
    console.error("Error at inserting", fileName, e);
  }
};

async function runScript(){
  await insertData("marcanet.json","marca");
  await insertData("vendedoresnet.json","vendedor");
  await insertData("productosnet.json","producto");
  await insertData("ventanet.json","venta");
}
runScript();

