import tsj from "ts-json-schema-generator";
import { writeFileSync } from "fs";

export default function (outputPath, type) {
  /** @type {import('ts-json-schema-generator/dist/src/Config').Config} */
  const config = {
    path: "./node_modules/antd/es/theme/interface/index.d.ts",
    tsconfig: "./tsconfig.json",
    type: type, // Or <type-name> if you want to generate schema for that one type only
  };

  const schema = tsj.createGenerator(config).createSchema(config.type);
  const schemaString = JSON.stringify(schema, null, 2);
  writeFileSync(outputPath, schemaString);
}
