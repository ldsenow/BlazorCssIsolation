import { unlinkSync, readdirSync } from "fs";
import { join } from "path";

import generateJsonSchema from "./generateJsonSchema.js";
import sanitizeTokens from "./sanitizeTokens.js";

const directory = "./schemas";

const types = [
  "PresetColorType",
  "ColorPalettes",
  "SeedToken",
  "MapToken",
  "ColorMapToken",
  "ColorNeutralMapToken",
  "CommonMapToken",
  "HeightMapToken",
  "SizeMapToken",
  "FontMapToken",
  "StyleMapToken",
  "AliasToken",
];

emptyFolder();

types.forEach((t) => {
  const file = join(directory, `${t}.json`);

  generateJsonSchema(file, t);
  sanitizeTokens(file);
});

function emptyFolder() {
  const files = readdirSync(directory);

  for (const file of files) {
    unlinkSync(join(directory, file));
  }
}
