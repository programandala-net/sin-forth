\ lib/tick.fs
\ by Marcos Cruz (programandala.net), 2020, 2023.
\ Last modified: 20230501T1817+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

\ ==============================================================
\ License

\ You may do whatever you want with this work, so long as you
\ retain every copyright, credit and authorship notice, and this
\ license.  There is no warranty.

\ ==============================================================

require sin_forth/lib/literal.fs

get-order get-current

compiler-definitions

: ' ( "name" -- dea )
  parse-name "_dea" s+ evaluate ;

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
