\ lib/tick.fs

\ This file is part of Sin Forth.

\ This file adds `tick` to the compiler.

\ By Marcos Cruz (programandala.net), 2020.

\ Last modified: 202012100043.
\ See change log at the end of the file.

\ ==============================================================

require sin_forth/lib/literal.fs

get-order get-current

compiler-definitions

: ' ( "name" -- dea )
  ' >body @ ;

  \ doc{
  \
  \ ' ( "name" -- dea )
  \
  \ Parse _name_ and return its _dea_ (dictionary entry address).
  \ The actual meaning of _dea_ depends on the definer word used to
  \ create _name_:
  \
  \ |===
  \ | Definer    | DEA
  \
  \ | `:`        | execution address
  \ | `constant` | address of its content
  \ | `variable` | address of its content
  \ |===
  \
  \ ``'`` is a compiler word, executed during the compilation.
  \
  \ }doc

set-current set-order

\ ==============================================================
\ Change log {{{1

\ 2020-12-10: Start.
