const generateJsonSchema = require("./generateJsonSchema");
const sanitizeTokens = require("./sanitizeTokens");

const types = [
  'PresetColorType',
  "SeedToken",
  "ColorPalettes",
  "ColorMapToken",
  "SizeMapToken",
  "HeightMapToken",
  "CommonMapToken",
  'NeutralColorMapToken',
  'MapToken',
  'AliasToken'
];

types.forEach((t) => {
  const file = `./schemas/${t}.json`;

  generateJsonSchema(file, t);
  sanitizeTokens(file);
});
