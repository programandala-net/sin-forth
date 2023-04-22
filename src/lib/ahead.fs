\ lib/ahead.fs

\ This file is part of Sin Forth.

\ This file adds `ahead` to the compiler.

\ By Marcos Cruz (programandala.net), 2020, 2023.

\ Last modified: 20230422T1751+0200.

\ ==============================================================

require branch.fs       \ `branch`
require forward-mark.fs \ `>mark`

get-order get-current

compiler-definitions

: ahead \ Compilation: ( C: -- orig )
        \ Run-time:    ( -- )
  $0000 compiler{ branch >mark } ;

  \ doc{
  \
  \ ahead
  \   Compilation: ( C: -- orig )
  \   Run-time:    ( -- )

  \
  \ Compilation: Compile an unconditional `branch` and put the
  \ location _orig_ of its unresolved destination on the
  \ control-flow stack.
  \
  \ Run-time: Continue execution at the location specified by the
  \ resolution of _orig_.
  \
  \ }doc

set-current set-order
