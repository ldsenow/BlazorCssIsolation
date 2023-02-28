import { rmSync, mkdirSync, existsSync } from "fs";
import { join } from "path";

import writeJsonSchema from "./writeJsonSchema.js";
import sanitizeJsonSchemaTokens from "./sanitizeJsonSchemaTokens.js";

const directory = "./generated/schemas";

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

setupFolder();

types.forEach((t) => {
  const file = join(directory, `${t}.json`);
  console.log(`********Generating ${t} to ${file}********`);

  writeJsonSchema(file, t);
  sanitizeJsonSchemaTokens(file);

  console.log(`********Generated ${t} to ${file}********`);
});

function setupFolder() {
  if (existsSync(directory)) {
    rmSync(directory, { recursive: true });
  }

  mkdirSync(directory, { recursive: true });
}
