const tsj = require("ts-json-schema-generator");
const fs = require("fs");

module.exports = function (outputPath) {
  /** @type {import('ts-json-schema-generator/dist/src/Config').Config} */
  const config = {
    path: "./node_modules/antd/es/theme/interface.d.ts",
    tsconfig: "./tsconfig.json",
    type: "AliasToken", // Or <type-name> if you want to generate schema for that one type only
  };

  const schema = tsj.createGenerator(config).createSchema(config.type);
  const schemaString = JSON.stringify(schema, null, 2);
  fs.writeFileSync(outputPath, schemaString);
};
