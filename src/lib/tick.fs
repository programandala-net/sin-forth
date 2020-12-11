\ lib/tick.fs

\ This file is part of Sin Forth.

\ This file adds `'` to the compiler.

\ By Marcos Cruz (programandala.net), 2020.

\ Last modified: 202012111721.
\ See change log at the end of the file.

\ ==============================================================

require sin_forth/lib/literal.fs

get-order get-current

compiler-definitions

: ' ( "name" -- dea )
  ' >body @ ;

  \ doc{
  \
  \ '  Compilation: ( "name" -- dea ) "tick"
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
  \ | `defer`    | execution address, which contains a Z80 ``jp``
  \ | `variable` | address of its content
  \ |===
  \
  \ See also: `[']`.
  \
  \ }doc

set-current set-order

\ ==============================================================
\ Change log {{{1

\ 2020-12-10: Start.
\
\ 2020-12-11: Improve and update the documentation.
