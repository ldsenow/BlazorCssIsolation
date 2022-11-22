const generateJsonSchema = require("./generateJsonSchema");
const sanitizeTokens = require("./sanitizeTokens");
const file = "./schema.json";
generateJsonSchema(file);
sanitizeTokens(file);
